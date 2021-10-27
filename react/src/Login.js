import React, { useState, useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Redirect } from 'react-router-dom';
import { Link } from 'react-router-dom';
import axios from 'axios';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Alert from '@material-ui/lab/Alert';
import { login } from "./actions/auth";

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

export default function Login() {
  const [loading, setLoading] = useState(false);
  const { isLoggedIn } = useSelector(state => state.auth);
  const { message } = useSelector(state => state.message);
  const dispatch = useDispatch();
  const classes = useStyles();
  const [user, setUser] = useState({ email: '', tz: '' })
  const [error, setError] = useState(false)
  const [redirect, setRedirect] = useState()
  const [noRedirect, setNoRedirect] = useState(false)
  //& (JSON.parse(localStorage.getItem('user').status) != 3))

  const handleLogin = (e) => {
    e.preventDefault();
    setLoading(true);
    dispatch(login(user))
      .then((res) => {
        debugger
        if (JSON.parse(localStorage.getItem('user')) && JSON.parse(localStorage.getItem('user').status != 3)) {
          setRedirect('/home')
          setNoRedirect(false)
        }
        else {
          setNoRedirect(true)
          setError(true)
        }
      })
  };

  if (redirect && noRedirect == false) {
    return <Redirect to={redirect} />;
  }
  else
    return (
      <div>
        <Container component="main" maxWidth="xs">
          <CssBaseline />
          <div className={classes.paper}>
            <Avatar className={classes.avatar}>
              <LockOutlinedIcon />
            </Avatar>
            <Typography component="h1" variant="h5">
              כניסה למערכת
                </Typography>
            <form className={classes.form} >
              <TextField
                variant="outlined"
                margin="normal"
                required
                fullWidth
                id="email"
                label="כתובת מייל"
                name="email"
                autoComplete="email"
                autoFocus
                onChange={(e) => { setUser({ email: e.target.value, tz: user.tz }) }}
              />
              <TextField
                variant="outlined"
                margin="normal"
                required
                fullWidth
                name="tz"
                label="תעודת זהות"
                type="text"
                id="tz"
                autoComplete="current-password"
                onChange={(e) => { setUser({ email: user.email, tz: e.target.value }) }}
              />
              <Button
                fullWidth
                variant="contained"
                color="primary"
                className={classes.submit}
                onClick={handleLogin}
              >
                כניסה
            </Button>
              {error ? <Alert severity="error">שם משתמש/סיסמא אינם נכונים, נסה שוב.</Alert> : null}
              <Grid container>
                <Grid item>
                  <Link to={"/signUpAddress"} style={{ color: '#212121' }} variant="body2">
                    {"אין לך חשבון? צור"}
                  </Link>
                </Grid>
              </Grid>
            </form>
          </div>
        </Container>
        {message && (
          <div className="form-group">
            <div className="alert alert-danger" role="alert">
              {message}
            </div>
          </div>
        )}

      </div>
    )
}

