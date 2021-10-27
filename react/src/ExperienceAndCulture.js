import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Button } from '@material-ui/core'
import Typography from "@material-ui/core/Typography";
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Container from '@material-ui/core/Container';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import axios from 'axios';
import { useDispatch, useSelector } from "react-redux";

const useStyles = makeStyles((theme) => ({
  container: {
    width: '80%',
    height: '80%'
  },
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    height: '80%'

  },
  calendar: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
    color: '#212121',
    mixBlendMode: 'luminosity'
  },
  submit: {
    width: 'auto',
    margin: theme.spacing(3, 0, 2),
  },
}));
export default function ExperienceAndCulture() {
  const classes = useStyles();
  const [events, setEvents] = useState([])
  const { user: currentUser } = useSelector((state) => state.auth);
  const [volunteer, setVolunteer] = useState([]);
  const [volunt, setVolunt] = useState([]);
  const [meetingEvent, setMeetingEvent] = useState([]);
  const [eventExperience, setEventExperience] = useState([]);
  const [eventOpen, setEventOpen] = useState(false)
  const [eventForAdd, setEventForAdd] = useState({ title: '', date: '', allDay: true })
  const [refreshVolunteer, setRefreshVolunteer] = useState(false);
  const [refreshEvent, setRefreshEvent] = useState(false);


  useEffect(() => {
    const url = 'https://localhost:44350/api/Meeting/GetMeetingsOfBuilding/'
    const newUrl = url + currentUser.id_building
    axios(newUrl, {
      method: "get",
      headers: {
        "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
      }
    }).then(res => {
      setMeetingEvent(res.data)
    })
  }, [])
  useEffect(() => {
    const url = 'https://localhost:44350/api/Event/GetEventsOfBuilding/'
    const newUrl = url + currentUser.id_building
    axios(newUrl, {
      method: "get",
      headers: {
        "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
      }
    }).then(res => {
      setEventExperience(res.data)
      setRefreshEvent(!refreshEvent)
    })
  }, [refreshVolunteer])

  useEffect(() => {
    if (meetingEvent && meetingEvent.length > 0 || eventExperience && eventExperience.length > 0) {
      const arrayForAll = []
      const m1 = meetingEvent && meetingEvent.map(item => ({ date: item.start_date, title: "תחילת ישיבת ועד", allDay: true }))
      const m2 = meetingEvent && meetingEvent.map(item => ({ date: item.end_date, title: "סיום ישיבת ועד", allDay: true }))
      const e1 = eventExperience && eventExperience.map(item => ({ date: item.event_date, title: item.title, allDay: true }))
      if (m1)
        m1.forEach(v => { arrayForAll.push(v) })
      if (m2)
        m2.forEach(v => { arrayForAll.push(v) })
      if (e1)
        e1.forEach(v => { arrayForAll.push(v) })
      setEvents(arrayForAll)
    }
  }, [meetingEvent, refreshEvent])
  console.log(events, "events")
  const saveEvent = () => {
    const eventSave = { event_date: eventForAdd.date, title: eventForAdd.title, event_building: currentUser.id_building }
    axios.post(`https://localhost:44350/api/Event/PostEvent`, eventSave)
      .then(res => {
        console.log(res.data, "eventsave");
        setRefreshVolunteer(!refreshVolunteer)
      }).catch(err => {
      })
    setEventOpen(false)
  }
  return (
    <Container component="main" className={classes.container}>
      <CssBaseline />
      <div className={classes.paper}>
        <Typography component="h1" variant="h5">
          לוח השנה שלי
            </Typography>
        {currentUser && currentUser.status == 1 ? <Button
          fullWidth
          variant="contained"
          color="primary"
          className={classes.submit}
          onClick={() => { setEventOpen(true) }}
        >הוספת ארוע
        </Button> : null}
        <div className={classes.calendar} >
          <FullCalendar
            plugins={[dayGridPlugin]}
            initialView="dayGridMonth"
            events={events}
          />
        </div>
        <Dialog open={eventOpen} onClose={() => { setEventOpen(false) }} >
          <DialogTitle id="form-dialog-title">הוספת ארוע ללוח שנה</DialogTitle>
          <DialogContent>
            <DialogContentText>
              וועד בית היקר. נא למלא פרטי הארוע
        </DialogContentText>
            <TextField
              autoFocus
              margin="dense"
              id="name"
              label="שם/כותרת הארוע"
              type="text"
              fullWidth
              onChange={(e) => { setEventForAdd({ title: e.target.value, date: eventForAdd.date }) }}
            />
            <TextField
              margin="dense"
              id="date"
              label="תאריך"
              type="date"
              fullWidth
              onChange={(e) => { setEventForAdd({ title: eventForAdd.title, date: e.target.value }) }}
            />
          </DialogContent>
          <DialogActions>
            <Button onClick={() => { setEventOpen(false) }} color="primary">
              ביטול
        </Button>
            <Button onClick={saveEvent} color="primary">
              שמור
        </Button>
          </DialogActions>
        </Dialog>
      </div>
    </Container>
  );
}