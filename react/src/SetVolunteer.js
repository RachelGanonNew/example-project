import React, { useState, useEffect } from 'react';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Alert from '@material-ui/lab/Alert';
import axios from 'axios';
import Input from '@material-ui/core/Input';

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

export default function SetVolunteer() {
    const classes = useStyles();
    const [user, setUser] = useState(JSON.parse(localStorage.getItem('user')))
    const [volunteeringArray, setVolunteeringArray] = useState()
    const [message, setMessage] = useState({ type: null, test: null })
    const [volunt, setVolunt] = useState({id_building:null,id_volunteering:null,id_volunteering_category:null,start_date:null,
    end_date:null,min_time:null,max_time:null,volunteering_description:null,status:null,requred:null})
    useEffect(() => {
          getVolunteer()
    }, [])
    const getVolunteer=()=>{
        const url = 'https://localhost:44350/api/Volunteering/GetVolunteeringsOfBuilding/'
            const newUrl = url + user.id_building
            axios(newUrl, {
                method: "get",
                headers: {
                    "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
                }
            }).then(res => {
                setVolunteeringArray(res.data.filter(t=>t.status==2))
            })
    }
    useEffect(() => {
        if (volunt.status==1) {
            axios.put(`https://localhost:44350/api/Volunteering/PutVolunteering`, volunt)
            .then(res => {
                console.log(res.data);
                setMessage({ type: 'success', text: 'עודכן:)' })
                getVolunteer()
            }).catch(err => {
                setMessage({ type: 'error', text: 'אראה שגיאה, לא עודכן:(' })
            })
        }
    }, [volunt])
    useEffect(() => {
        if (message.type) {
          setTimeout(() => {
            setMessage({ type: null, text: null })
          }, 2000)
        }
      }, [message])
    const send_email = (e, d) => {
        console.log(d)
        setVolunt({id_building:d.id_building,id_volunteering:d.id_volunteering,id_volunteering_category:d.id_volunteering_category
        ,start_date:d.start_date,end_date:d.end_date,min_time:d.min_time,max_time:d.max_time,volunteering_description:d.volunteering_description,status:1,requred:d.requred})
    }

return (
    <Container component="main" maxWidth="xs">
        <CssBaseline />
        <div className={classes.paper}>
            {volunteeringArray&&volunteeringArray.length>0 ? volunteeringArray.map(d => (<>
                <Input defaultValue={d.volunteering_description} color="secondary" disabled />
                <Button onClick={(e) => { send_email(e.target.value, d) }} color="primary">
אשר        </Button>
            </>
            )) : 
        <Typography component="h1" variant="h5">
            אין התנדבויות שמחכות לאישור
        </Typography>}
            {message.type ? <Alert severity={message.type}>{message.text}</Alert> : null}
        </div>
    </Container>
);
            }
