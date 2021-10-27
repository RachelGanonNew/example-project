import React,{useState, useEffect} from "react";
import { makeStyles } from "@material-ui/core/styles";
import Paper from "@material-ui/core/Paper";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import {Link} from 'react-router-dom'


const useStyles = makeStyles({
  root: {
    flexGrow: 1,
  },
});

const getActiveTab = () => {

  const tabs = ["/home", "/payment", "/budget","/experienceAndCulture","/volunteering","/meetingRoom"]
  const index = tabs.indexOf(window.location.pathname)

  return index > 0  ? index : 0;
};

export default () => {
  const classes = useStyles();
  const [value, setValue] = useState(getActiveTab());
  const [user, setUser] = useState();

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <Paper className={classes.root}>
      <Tabs
        value={value}
        onChange={handleChange}
        indicatorColor="primary"
        textColor="primary"
        centered
      >
        <Tab label="בית"  component={Link} to="/home" />
        <Tab label="תשלום"  component={Link} to="/payment" />
        <Tab label="תקציב"  component={Link} to="/budget" />
        <Tab label="הווי ותרבות"  component={Link} to="/experienceAndCulture" />
        <Tab label="התנדבות"  component={Link} to="/volunteering" />
        <Tab label="חדר ישיבות"  component={Link} to="/meetingRoom" />
      </Tabs>
    </Paper>
  );
};
