import React, { useState } from 'react';
import { Redirect } from "react-router-dom";
import { Link } from 'react-router-dom';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import LocationCityIcon from '@material-ui/icons/LocationCity';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
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
export default function SignUpNewBuilding({ ...props }) {
    const classes = useStyles();
    const [numBuilding, setNumBuilding] = useState({ floorNum: 0, apartments_num: 0 ,monthCost:0})
    const [idBuilding, setIdBuilding] = useState(0)

    const [redirect, setRedirect] = useState()
    const onSubmit = () => {
        const newBuilding = {
            city: props.location.state.value.building.city, street: props.location.state.value.building.street,
            street_num: props.location.state.value.building.street_num, floors_num: numBuilding.floorNum,
            apartments_num: numBuilding.apartments_num,month_cost:numBuilding.monthCost
        }
        axios.post(`https://localhost:44350/api/building/PostBuilding`, newBuilding)
            .then(res => {
                setIdBuilding(res.data)
                localStorage.setItem('manager', true)
                localStorage.setItem('building', res.data)
                setRedirect('/signUpTenant')
            })
    }
    if (redirect) {
        return <Redirect to={{
            pathname: redirect,
            state: { value: { numBuilding: numBuilding, idBuildin: idBuilding } }
        }} />;
    }
    else
        return (
            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <div className={classes.paper}>
                    <Avatar className={classes.avatar}>
                        <LocationCityIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        צור את הבניין שלך
            </Typography>
                    <form className={classes.form} >
                        <TextField
                            variant="outlined"
                            margin="normal"
                            required
                            fullWidth
                            id="floorNum"
                            label="מס' קומות"
                            name="floorNum"
                            type="number"
                            autoFocus
                            onChange={(e) => { setNumBuilding({ floorNum: e.target.value, apartments_num: numBuilding.apartments_num,monthCost:numBuilding.monthCost }) }} />
                        <TextField
                            variant="outlined"
                            margin="normal"
                            required
                            fullWidth
                            name="apartments_num"
                            label="מס' דירות"
                            type="number"
                            id="apartments_num"
                            onChange={(e) => { setNumBuilding({ floorNum: numBuilding.floorNum, apartments_num: e.target.value,monthCost:numBuilding.monthCost }) }} />
                            <TextField
                            variant="outlined"
                            margin="normal"
                            required
                            fullWidth
                            name="month_cost"
                            label="עלות חודשית"
                            type="number"
                            id="month_cost"
                            onChange={(e) => { setNumBuilding({ floorNum: numBuilding.floorNum, apartments_num: numBuilding.apartments_num,monthCost:e.target.value }) }} />
                        
                        <Button
                            fullWidth
                            variant="contained"
                            color="primary"
                            className={classes.submit}
                            onClick={onSubmit}
                        >
                            הבא
        </Button>
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