import React, { useState, useEffect } from "react";
import { Formik, useFormik } from "formik";
import * as Yup from "yup";
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import PersonIcon from '@material-ui/icons/Person';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import { Link } from 'react-router-dom';
import { Redirect } from "react-router-dom";
import axios from 'axios';

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

export default function SignUpTenant() {
    const classes = useStyles();
    const [user, setUser] = useState({ FName: '', LName: '', id: '', phone: '', email: '', apartments_num: '', floor_num: '' })
    const [redirect, setRedirect] = useState()
    const [building, setBuilding] = useState()
    const [mail, setMail] = useState({ title: '', body: '' })


    useEffect(() => {
        const url = 'https://localhost:44350/api/Building/GetBuildingById/'
        const newUrl = url + JSON.parse(localStorage.getItem('building'))
        axios(newUrl, {
            method: "get",
            headers: {
                "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
            }
        }).then(res => {
            setBuilding(res.data)
        })
    }, [])
    console.log(JSON.parse(localStorage.getItem('building')), "building")
    const saveTenant = (i) => {
        const t = localStorage.getItem('manager') ? 1 : 3//???
        setMail({ title: "תודה שנרשמתם ל my_building", body: "תודה שנרשמתם לmy_building" })
        if (t === 1) {
            setMail({ title: mail.title, body: "תודה שנרשמתם לmy_building הרשמתכם מחכה לאישור הוועד" })
        }
        const id_building = JSON.parse(localStorage.getItem('building'))
        const newUser = {
            id_tenant: 0, id_building: JSON.parse(localStorage.getItem('building')), first_name: i.FName, last_name: i.LName, tz: i.id,
            phone: i.phone, email: i.email, apartment_num: i.apartments_num,
            floor_num: i.floor_num, status: t
        }
        const newEmail = {
            toEmail: i.email, fromEmail: "mybuildingnoreplay@gmail.com", subjectOfEmail: mail.title, bodyOfEmail: mail.body
        }

        axios.post(`https://localhost:44350/api/tenant/PostTenant`, newUser)
            .then(res => {
                debugger
                // if(res.data.status != 1){
                //     const newEmailToManeger = {toEmail: , fromEmail: "mybuildingnoreplay@gmail.com", subjectOfEmail: "דייר חדש מחכה לאישור", bodyOfEmail: ""}
                //     axios.post(`https://localhost:44350/api/tenant/PostEmailToTenant`, newEmailToManeger)
                // }
                axios.post(`https://localhost:44350/api/tenant/PostEmailToTenant`, newEmail)
                setRedirect('/login')
            })
    }

    const formik = useFormik({
        initialValues: {
            FName: '', LName: '', id: '', phone: '', email: '', apartments_num: "", floor_num: ""
        },
        validationSchema: Yup.object({
            FName: Yup.string()
                .required('שם פרטי חובה'),
            LName: Yup.string()
                .required('שם משפחה חובה'),
            email: Yup.string()
                .email('כתובת מייל לא תקינה')
                .required('כתובת מייל חובה'),
            id: Yup.string()
                .min(9, 'ת.ז. צריך להיות 9 ספרות')
                .max(9, 'ת.ז. צריך להיות 9 ספרות')
                .required('ת.ז. חובה'),
            phone: Yup.string()
                .required('נייד חובה'),
            apartments_num: Yup.number()
                .required('מספר דירה חובה').max(building ? building.apartments_num : 10, "אין מס' דירה כזה בבנין"),
            floor_num: Yup.number()
                .required('קומה חובה').max(building ? building.floors_num : 10, "אין קומה כזו בבנין")
        }),
        onSubmit: (values) => {
            saveTenant(formik.values)
        }
    });
    if (redirect) {
        return <Redirect to={redirect} />;
    }
    else
        return (
            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <div className={classes.paper}>
                    <Avatar className={classes.avatar}>
                        <PersonIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        הכנס פרטייך            </Typography>
                    <form onSubmit={formik.handleSubmit}>
                        <div>
                            <TextField
                                variant="outlined"
                                margin="normal"
                                fullWidth
                                name="FName"
                                label="שם פרטי"
                                value={formik.values.FName}
                                onChange={formik.handleChange}
                            />
                            {formik.errors.FName && formik.touched.FName && (
                                <p>{formik.errors.FName}</p>)}
                        </div>
                        <div>
                            <TextField
                                variant="outlined"
                                margin="normal"
                                fullWidth
                                name="LName"
                                label="שם משפחה"
                                value={formik.values.LName}
                                onChange={formik.handleChange}
                            />
                            {formik.errors.LName && formik.touched.LName && (
                                <p>{formik.errors.LName}</p>)}
                        </div>
                        <div>
                            <TextField
                                variant="outlined"
                                margin="normal"
                                fullWidth
                                name="id"
                                label="תעודת זהות"
                                value={formik.values.id}
                                onChange={formik.handleChange}
                            />
                            {formik.errors.id && formik.touched.id && (
                                <p>{formik.errors.id}</p>)}
                        </div>
                        <div>
                            <TextField
                                variant="outlined"
                                margin="normal"
                                fullWidth
                                name="email"
                                label="אימייל"
                                value={formik.values.email}
                                onChange={formik.handleChange}
                            />
                            {formik.errors.email && formik.touched.email && (
                                <p>{formik.errors.email}</p>)}
                        </div>
                        <div>
                            <TextField
                                variant="outlined"
                                margin="normal"
                                fullWidth
                                name="phone"
                                label="נייד"
                                value={formik.values.phone}
                                onChange={formik.handleChange}
                            />
                            {formik.errors.phone && formik.touched.phone && (
                                <p>{formik.errors.phone}</p>)}
                        </div>
                        <div>
                            <TextField
                                variant="outlined"
                                margin="normal"
                                fullWidth
                                name="apartments_num"
                                label="מספר דירה"
                                value={formik.values.apartments_num}
                                onChange={formik.handleChange}
                            />
                            {formik.errors.apartments_num && formik.touched.apartments_num && (
                                <p>{formik.errors.apartments_num}</p>)}
                        </div>
                        <div>
                            <TextField
                                variant="outlined"
                                margin="normal"
                                fullWidth
                                name="floor_num"
                                label="קומה"
                                value={formik.values.floor_num}
                                onChange={formik.handleChange}
                            />
                            {formik.errors.floor_num && formik.touched.floor_num && (
                                <p>{formik.errors.floor_num}</p>)}
                        </div>
                        <div>
                            <Button
                                fullWidth
                                variant="contained"
                                color="primary"
                                type="submit"
                                className={classes.submit}
                                onClick={formik.handleSubmit}
                            >
                                הרשם
</Button>
                        </div>
                        <Grid container>
                            <Grid item>
                                <Link to={"/login"} style={{ color: '#212121' }} variant="body2">
                                    {"יש לך חשבון? היכנס"}
                                </Link>
                            </Grid>
                        </Grid>
                    </form>
                </div>
            </Container>

        );
}

