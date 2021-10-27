import React, { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Router, Switch, Route, Link } from "react-router-dom";

import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import Login from "./Login";
import Home from "./Home";

import { logout } from "./actions/auth";
import { clearMessage } from "./actions/message";

import { history } from "./helpers/history";
import Payment from "./Payment";
import ExperienceAndCulture from "./ExperienceAndCulture";
import Budget from "./Budget";
import SignUpAddress from "./SignUpAddress";
import SignUpNewBuilding from "./SignUpNewBuilding";
import SignUpTenant from "./SignUpTenant";
import MeetingRoom from "./MeetingRoom";
import Volunteering from "./Volunteering";
import SendEmail from "./SendEmail";
import SetVolunteer from "./SetVolunteer";
import { createMuiTheme, makeStyles, ThemeProvider } from "@material-ui/core";

const theme = createMuiTheme({
  palette: {
    primary: {
      main: "#1a237e"
    },
    secondary: { main: "#1a237e" }
  }
})
const useStyles = makeStyles((theme) => ({
  body: {
    direction: 'rtl',
    flex: 'auto'
  },
  body1: {
    backgroundColor: '#1a237e !important',
  },
}));

const App = () => {
  const { user: currentUser } = useSelector((state) => state.auth);
  const dispatch = useDispatch();
  const styles = useStyles();

  useEffect(() => {
    history.listen((location) => {
      dispatch(clearMessage()); // clear message when changing location
    });
  }, [dispatch]);

  const logOut = () => {
    dispatch(logout());
  };

  return (
    <Router history={history}>
      <div >
        <ThemeProvider theme={theme}>
          <nav className={`${styles.body1} ${"navbar navbar-expand navbar-dark bg-dark"}`}>
            <Link className="navbar-brand">
              my building
          </Link>
            <div className={`${styles.body} ${"navbar-nav mr-auto"}`}>
              {currentUser && (<>
                <li className="nav-item">
                  <Link to={"/home"} className="nav-link">
                    בית
                </Link>
                </li>
                <li className="nav-item">
                  <Link to={"/payment"} className="nav-link">
                    תשלום
              </Link>
                </li>
                <li className="nav-item">
                  <Link to={"/budget"} className="nav-link">
                    תקציב
                </Link>
                </li>
                <li className="nav-item">
                  <Link to={"/meetingRoom"} className="nav-link">
                    חדר ישיבות
                </Link>
                </li>
                <li className="nav-item">
                  <Link to={"/volunteering"} className="nav-link">
                    התנדבות
                </Link>
                </li>
                <li className="nav-item">
                  <Link to={"/experienceAndCulture"} className="nav-link">
                    הווי ותרבות
                </Link>
                </li>
              </>
              )}
            </div>

            {currentUser ? (
              <div className="navbar-nav ml-auto">
                <li className="nav-item">
                  <Link to={"/home"} className="nav-link">
                  </Link>
                </li>
                <li className="nav-item">
                  <a href="/login" className="nav-link" onClick={logOut}>
                    התנתק
                </a>
                </li>
              </div>
            ) : (
              <div className="navbar-nav ml-auto">
                <li className="nav-item">
                </li>
              </div>
            )}
          </nav>
          <div className="container mt-3">
            <Switch>
              <Route exact path={["/", "/login"]} component={Login} />
              <Route path="/home" component={Home} />
              <Route path="/payment" component={Payment} />
              <Route path="/budget" component={Budget} />
              <Route path="/experienceAndCulture" component={ExperienceAndCulture} />
              <Route path="/volunteering" component={Volunteering} />
              <Route path="/meetingRoom" component={MeetingRoom} />
              <Route path="/signUpTenant" component={SignUpTenant} />
              <Route path="/setVolunteer" component={SetVolunteer} />
              <Route path="/sendEmail" component={SendEmail} />
              <Route path="/signUpAddress" component={SignUpAddress} />
              <Route path="/signUpNewBuilding" component={SignUpNewBuilding} />
            </Switch>
          </div>
        </ThemeProvider>
      </div>

    </Router>

  );
};

export default App;