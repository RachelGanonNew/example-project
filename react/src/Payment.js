import React, { useState, useEffect } from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import PaymentIcon from '@material-ui/icons/Payment';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Alert from '@material-ui/lab/Alert';
import axios from 'axios';
import { Redirect } from "react-router-dom";
import Moment from 'moment';
import { useDispatch, useSelector } from "react-redux";
import DoneIcon from '@material-ui/icons/Done';
import IconButton from '@material-ui/core/IconButton';

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

export default function Payment() {
    const classes = useStyles();
    const [pay, setPay] = useState(0)
    const { user: currentUser } = useSelector((state) => state.auth);
    const [monthCost, setMonthCost] = useState(0)
    const [tanants, setTanants] = useState()
    const [redirect, setRedirect] = useState(null)
    const [today, setToday] = useState(Moment(new Date()).format('yyyy-MM-DD'))
    const [monthName, setMonthName] = useState()
    const [monthCostManager, setMonthCostManager] = useState(null)
    const [fullDetails, setFullDetails] = useState({ id: null, numCard: null, endDate: null, backNum: null, sum: null })
    const [display1, setDisplay1] = useState(true)

    useEffect(() => {
        if (fullDetails.id && fullDetails.numCard && fullDetails.endDate && fullDetails.backNum && fullDetails.sum) {
            console.log("here")
            setDisplay1(false)
        }
    }, [fullDetails])
    console.log(display1)
    const onSubmit = () => {
        const newUser = {
            id_tenant: currentUser.id_tenant, payment_date: new Date(), payment_month: new Date().getMonth() + 1, done: 1,
            id_building: currentUser.id_building
        }
        console.log(newUser, "nu")
        axios.post(`https://localhost:44350/api/payment/PostPayment`, newUser)
            .then(res => {
                console.log(res.data);
                setPay(pay + 1)
            })
    }
    useEffect(() => {
        if (pay > 3)
            setPay(0)
    }, [pay])
    useEffect(() => {
        if (currentUser.status == 1) {
            const url = 'https://localhost:44350/api/tenant/GetTenantsOfBuilding/'
            const newUrl = url + currentUser.id_building
            axios(newUrl, {
                method: "get",
                headers: {
                    "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
                }
            }).then(res => {
                setTanants(res.data)
                console.log(res);
            })
        }
    }, [])
    useEffect(() => {
        const url = 'https://localhost:44350/api/Building/GetBuildingById/'
        const newUrl = url + currentUser.id_building
        axios(newUrl, {
            method: "get",
            headers: {
                "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
            }
        }).then(res => {
            const year = ["ינואר", "פברואר", "מרץ", "אפריל", "מאי", "יוני", "יולי", "אוגוסט", "ספטמבר", "אוקטובר", "נובמבר", "דצמבר"]
            setMonthCost(res.data)
            setMonthName(year[new Date().getMonth()])
            console.log(res.data, "building details");
        })
    }, [])
    const changeMonthCost = () => {
        const updateBuilding = {
            id_building: monthCost.id_building, city: monthCost.city, street: monthCost.street, street_num: monthCost.street_num
            , floors_num: monthCost.floors_num, apartments_num: monthCost.apartments_num, tenants: monthCost.tenants, id_tenantManager: monthCost.id_tenantManager
            , month_cost: monthCostManager, cash_box: monthCost.cash_box, professonal: monthCost.professonal
        }
        axios.put(`https://localhost:44350/api/Building/PutBuilding`, updateBuilding)
            .then(res => {
                console.log(res.data);
                setMonthCost({
                    apartments_num: monthCost.apartments_num, cash_box: monthCost.cash_box, city: monthCost.city, floors_num: monthCost.floors_num,
                    id_building: monthCost.id_building, month_cost: monthCostManager, street: monthCost.street, street_num: monthCost.street_num
                })
            }).catch(err => {
            })
    }
    const onSend = () => {
        setRedirect('/sendEmail')
    }
    if (redirect) {
        return <Redirect to={redirect} />;
    }
    return (
        <Container component="main" maxWidth="xs">
            <CssBaseline />
            <div className={classes.paper}>
                <Avatar className={classes.avatar}>
                    <PaymentIcon />
                </Avatar>
                {monthCost && monthCost.month_cost ?
                    <Typography component="h1" variant="h5">
                        תשלום לחודש {monthName}  סה"כ {monthCost.month_cost}</Typography> : null}
                {currentUser && currentUser.status == 1 ? <div>
                    <TextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        label="שנה סכום חודשי"
                        type="number"
                        onChange={e => setMonthCostManager(e.target.value)} />
                    <IconButton onClick={changeMonthCost}>
                        <DoneIcon />
                    </IconButton>
                </div> : null}
                <form className={classes.form} >
                    <TextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        label="תעודת זהות"
                        InputProps={{ inputProps: { minLength: 9, maxLength: 9 } }}
                        autoFocus
                        onChange={(e) => { setFullDetails({ id: e.target.value, numCard: fullDetails.numCard, endDate: fullDetails.endDate, backNum: fullDetails.backNum, sum: fullDetails.sum }) }} />
                    <TextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        label="מספר כרטיס אשראי"
                        InputProps={{ inputProps: { minLength: 8, maxLength: 16 } }}
                        onChange={(e) => { setFullDetails({ id: fullDetails.id, numCard: e.target.value, endDate: fullDetails.endDate, backNum: fullDetails.backNum, sum: fullDetails.sum }) }} />
                    <TextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        label="תוקף כרטיס"
                        type="date"
                        InputProps={{ inputProps: { min: today } }}
                        onChange={(e) => { setFullDetails({ id: fullDetails.id, numCard: fullDetails.numCard, endDate: e.target.value, backNum: fullDetails.backNum, sum: fullDetails.sum }) }} />
                    <TextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        label="שלש ספרות בגב הכרטיס"
                        InputProps={{ inputProps: { maxLength: 3, minLength: 3 } }}
                        onChange={(e) => { setFullDetails({ id: fullDetails.id, numCard: fullDetails.numCard, endDate: fullDetails.endDate, backNum: e.target.value, sum: fullDetails.sum }) }} />
                    <TextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        label="הסכום לתשלום"
                        type="number"
                        onChange={(e) => { setFullDetails({ id: fullDetails.id, numCard: fullDetails.numCard, endDate: fullDetails.endDate, backNum: fullDetails.backNum, sum: e.target.value }) }} />
                    <Button
                        fullWidth
                        variant="contained"
                        color="primary"
                        className={classes.submit}
                        onClick={onSubmit}
                        disabled={display1 == true ? true : false}
                    >
                        אישור
        </Button>
                    {pay >= 1 && pay <= 3 ? <Alert severity="success">התשלום בוצע בהצלחה</Alert> : null}
                    {pay > 3 ? <Alert severity="error">שם משתמש/סיסמא אינם נכונים, נסה שוב.</Alert> : null}
                </form>
                {currentUser && currentUser.status == 1 ? <Button
                    fullWidth
                    variant="contained"
                    color="secondary"
                    className={classes.submit}
                    onClick={onSend}
                >
                    שליחת מייל תזכורת תשלום לדיירים
        </Button> : null}
            </div>
        </Container>
    );
}