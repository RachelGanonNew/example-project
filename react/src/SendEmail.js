import React, { useState, useEffect } from 'react';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Alert from '@material-ui/lab/Alert';
import axios from 'axios';
import Input from '@material-ui/core/Input';
import ClearIcon from '@material-ui/icons/Clear';
import CheckIcon from '@material-ui/icons/Check';
import Moment from 'moment';

const useStyles = makeStyles((theme) => ({
    paper: {
        marginTop: theme.spacing(8),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    },
    avatar: {
        margin: theme.spacing(1),
        backgroundColor: theme.palette.secondary.main,
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(1),
    },
    submit: {
        margin: theme.spacing(3, 0, 2),
    },
}));


export default function SendEmail() {
    const classes = useStyles();
    const [user, setUser] = useState(JSON.parse(localStorage.getItem('user')))
    const [tanants, setTanants] = useState()
    const [message, setMessage] = useState({ type: null, test: null })
    const [tanantsForPrint, setTanantsForPrint] = useState()
    const [today, setToday] = useState(parseInt(Moment(new Date()).format('M')))
    const [mail, setMail] = useState({ title: '', body: '' })


    useEffect(() => {
        debugger
        if (user.status == 1) {
            const url = 'https://localhost:44350/api/tenant/GetTenantsOfBuilding/'
            const newUrl = url + user.id_building
            axios(newUrl, {
                method: "get",
                headers: {
                    "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
                }
            }).then(res => {
                setTanants(res.data)
            })
        }
    }, [])
    useEffect(() => {
        const url = 'https://localhost:44350/api/Payment/GetPaymentsOfBuilding/'
        const newUrl = url + user.id_building
        axios(newUrl, {
            method: "get",
            headers: {
                "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
            }
        }).then(res => {
            if (tanants && tanants.length > 0) {
                let pp = tanants.map(item => ({
                    id_tenant: item.id_tenant, first_name: item.first_name, last_name: item.last_name, status: item.status
                    , email: item.email, pay: 0
                }))
                debugger
                let arr = res.data.filter(t => t.payment_month == today)
                if (arr) {
                    debugger
                    for (let i = 0; i < arr.length; i++) {

                        pp.filter(y => y.id_tenant == arr[i].id_tenant)[0].pay = 1
                    }
                } else pp.filter(y => y.id_tenant)[0].pay = 0
                setTanantsForPrint(pp)
                console.log(res);
            }
        })
    }, [tanants])
    console.log(tanantsForPrint, "tfp")



    const handleSentToAll = () => {
        //   tanantsForPrint && tanantsForPrint.length > 1 ? tanantsForPrint.filter(t => t.status != 3).map(d => (
        //        d.pay == 1 ? send_email(d) : null)) : null
    }

    const send_email = (e, d) => {
        setMail({ title: "קבלת הודעה מועד הבית", body: "תזכורת תשלום דמי ועד" })
        const tenantEmail = { toEmail: d.email, fromEmail: "mybuildingnoreplay@gmail.com", subjectOfEmail: mail.title, bodyOfEmail: mail.body }
        console.log(tenantEmail)
        axios.post(`https://localhost:44350/api/Tenant/PostEmailToTenant`, tenantEmail)
            .then(res => {
                setMessage({ type: 'success', text: 'האימייל נשלח בהצלחה:)' })
                console.log(res);
            })
            .catch(err => {
                setMessage({ type: 'error', text: 'אראה שגיאה, האימייל לא נשלח:(' })
            })
    }

    useEffect(() => {
        if (message.type) {
            setTimeout(() => {
                setMessage({ type: null, text: null })
            }, 2000)
        }
    }, [message])

    return (
        <Container component="main" maxWidth="xs">
            <CssBaseline />
            <div className={classes.paper}>
                {tanantsForPrint && tanantsForPrint.length > 1 ? tanantsForPrint.filter(t => t.status != 3).map(d => (<>
                    {d.pay == 1 ? <CheckIcon /> : <ClearIcon />}
                    <Input defaultValue={d.first_name + ' ' + d.last_name} color="secondary" disabled />
                    <Button onClick={(e) => { send_email(e.target.value, d) }} color="primary">
                        שלח תזכורת
        </Button>
                </>
                )) : <Typography component="h1" variant="h5">
                    אין דיירים לבניין
    </Typography>}
                {message.type ? <Alert severity={message.type}>{message.text}</Alert> : null}

                {user && user.status == 1 ?
                    <Button
                        color="primary"
                        onClick={handleSentToAll}
                    >
                        שלח תזכורת לכל הדיירים
</Button> : null
                }

            </div>
        </Container>
    );
}