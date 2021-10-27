import React, { useState ,useEffect} from 'react';
import { Link, Redirect } from 'react-router-dom';
import axios from 'axios';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import LocationCityIcon from '@material-ui/icons/LocationCity';
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

export default function SignUpAddress() {
    const classes = useStyles();
    const [building, setBuilding] = useState({ city: '', street: '', street_num: 0 })
    const [id_building, setIdBuilding] = useState()
    const [redirect, setRedirect] = useState()
    useEffect(() => {
       if(JSON.parse(localStorage.getItem('manager')))
            localStorage.removeItem('manager')
        if(JSON.parse(localStorage.getItem('tenants')))
            localStorage.removeItem('tenants')
    }, [])
    const onSubmit = () => {
        console.log(building)
        axios.post('https://localhost:44350/api/Building/GetBuildingByAddres', building).then(
            res => {
                const buildingExist = res.data;
                if(res.data)
                {
                    setIdBuilding(res.data.id_building)
                    localStorage.setItem('building', res.data.id_building)
                }
                buildingExist != null ? setRedirect('/signUpTenant') : setRedirect('/signUpNewBuilding')
            })
    }
        if (redirect) {
            return <Redirect to={{
                pathname: redirect,
                state: { value: {building,idBuildin:id_building} }
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
                        צור חשבון
            </Typography>
                    <form className={classes.form} >
                        <TextField
                            variant="outlined"
                            margin="normal"
                            required
                            fullWidth
                            id="city"
                            label="עיר"
                            name="city"
                            autoComplete="city"
                            autoFocus
                            onChange={(e) => { setBuilding({ city: e.target.value, street: building.street, street_num: building.num }) }} />
                        <TextField
                            variant="outlined"
                            margin="normal"
                            required
                            fullWidth
                            id="street"
                            label="רחוב"
                            name="street"
                            onChange={(e) => { setBuilding({ city: building.city, street: e.target.value, street_num: building.num }) }} />
                        <TextField
                            variant="outlined"
                            margin="normal"
                            required
                            fullWidth
                            name="street_num"
                            label="מס' בניין"
                            type="number"
                            id="street_num"
                            onChange={(e) => { setBuilding({ city: building.city, street: building.street, street_num: e.target.value }) }} />
                        <Button
                            fullWidth
                            variant="contained"
                            color="primary"
                            className={classes.submit}
                            onClick={onSubmit}
                        >
                            כניסה
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