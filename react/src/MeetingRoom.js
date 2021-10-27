import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Container, Button } from '@material-ui/core'
import Typography from "@material-ui/core/Typography";
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import axios from 'axios';
import SentimentVeryDissatisfiedIcon from '@material-ui/icons/SentimentVeryDissatisfied';
import SentimentSatisfiedAltIcon from '@material-ui/icons/SentimentSatisfiedAlt';
import CommentsBlock from 'simple-react-comments';
import Alert from '@material-ui/lab/Alert';
import IconButton from '@material-ui/core/IconButton';
import CancelIcon from '@material-ui/icons/Cancel';
import Moment from 'moment';
import { useDispatch, useSelector } from "react-redux";
import { Doughnut } from 'react-chartjs-2';

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
  },
  calendar: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
    height: '80%'
  },
  submit: {
    width: 'auto',
    margin: theme.spacing(3, 0, 2),
  },
}));
export default function MeetingRoom() {
  const classes = useStyles();
  const [meeting, setMeeting] = useState({ title: '', body: '', start_date: '', end_date: '' });
  const { user: currentUser } = useSelector((state) => state.auth);
  const [eventOpen, setEventOpen] = useState(false)
  const [mee, setMee] = useState()
  const [today, setToday] = useState(Moment(new Date()).format('yyyy-MM-DD'))
  const [meetingToAdd, setMeetingToAdd] = useState({
    meeting_subject: null, start_date: null,
    end_date: null, meeting_description: null, id_building: null
  })
  const [comments, setComments] = useState([{ id_meeting: '', createdAt: new Date(), fullName: '', text: "רשום את התגובה הראשונה" }])
  const [refreshComment, setRefreshComment] = useState(false)
  const [refreshMeetting, setRefreshMeetting] = useState(false)
  const [message, setMessage] = useState({ type: null, test: null })
  const [voteForId, setVoteForId] = useState()
  const [voteData, setVoteData] = useState()

  const saveEvent = () => {
    setMeetingToAdd({
      meeting_subject: meeting.title, start_date: meeting.start_date,
      end_date: meeting.end_date, meeting_description: meeting.body, id_building: currentUser.id_building
    })
  }
  useEffect(() => {
    const url = 'https://localhost:44350/api/Meeting/GetMeetingsOfBuilding/'
    const newUrl = url + currentUser.id_building
    axios(newUrl, {
      method: "get",
      headers: {
        "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
      }
    }).then(res => {
      console.log(res);
      setMee(res.data ? res.data.filter(t => new Date(t.start_date) <= new Date() && new Date(t.end_date) >= new Date()) : null)
    })
  }, [refreshMeetting])
  console.log(mee, "meeting")
  useEffect(() => {
    const url = 'https://localhost:44350/api/Comment/GetCommentsOfBuilding/'
    const newUrl = url + currentUser.id_building
    axios(newUrl, {
      method: "get",
      headers: {
        "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
      }
    }).then(res => {
      const newItemInput = (res.data ? res.data.map(item => ({ id_meeting: item.id_meeting, createdAt: new Date(item.comment_date), fullName: JSON.parse(localStorage.getItem('tenants')).filter(o => o.id_tenant == item.id_tenant)[0].first_name + ' ' + JSON.parse(localStorage.getItem('tenants')).filter(o => o.id_tenant == item.id_tenant)[0].last_name, text: item.comment_description })) : null)
      if (newItemInput && newItemInput.length > 0) {
        setComments(newItemInput)
      }
    })
  }, [refreshComment])

  useEffect(() => {
    if (meetingToAdd.meeting_subject) {
      axios.post(`https://localhost:44350/api/Meeting/PostMeeting`, meetingToAdd)
        .then(res => {
          setEventOpen(false)
          setRefreshMeetting(!refreshMeetting)
        })
    }
  }, [meetingToAdd])
  useEffect(() => {
    if (message.type) {
      setTimeout(() => {
        setMessage({ type: null, text: null })
      }, 1000)
    }
  }, [message])

  const handleVote = (t, option) => {
    const vote = {
      id_meeting: option.id_meeting, vote_subject: t, vote_description: null,
      tenants_vote: null, id_building: currentUser.id_building, id_tenant: currentUser.id_tenant
    }
    const url = 'https://localhost:44350/api/Vote/GetVoteByIdMeeting/'
    const newUrl = url + option.id_meeting
    axios(newUrl, {
      method: "get",
      headers: {
        "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
      }
    }).then(res => {
      if (res.data && res.data.length > 0 && res.data.filter(c => c.id_tenant == currentUser.id_tenant)) {
        setMessage({ type: 'error', text: 'לא ניתן להצביע שנית:(' })
        return;
      }
      else {
        axios.post(`https://localhost:44350/api/Vote/PostVote`, vote)
          .then(res => {
            setMessage({ type: 'success', text: 'הצבעתך נשמרה:)' })
          })
      }
    })
  }
  const showVote = (e, option) => {
    const url = 'https://localhost:44350/api/Vote/GetVoteByIdMeeting/'
    const newUrl = url + option.id_meeting
    axios(newUrl, {
      method: "get",
      headers: {
        "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
      }
    }).then(res => {
      setVoteData({
        labels: ["בעד", "נגד"],
        datasets: [
          {
            data: [res.data.filter(t => t.vote_subject == "1").length, res.data.filter(t => t.vote_subject == "2").length],
            backgroundColor: [
              "rgba(255, 99, 132, 0.6)", "rgba(54, 162, 235, 0.6)"]
          }
        ]
      })
    })
  }
  const handleComment = (t, option) => {
    const tt = { id_meeting: option.id_meeting, id_tenant: currentUser.id_tenant, comment_description: t, comment_date: new Date(), id_building: currentUser.id_building }
    axios.post(`https://localhost:44350/api/Comment/PostComment`, tt)
      .then(res => {
        setRefreshComment(!refreshComment)
      })
  }
  return (
    <Container component="main" className={classes.container}>
      <CssBaseline />
      <div className={classes.paper}>
        <Typography component="h1" variant="h5">
          ניהול חדר ישיבות
            </Typography>
        {currentUser && currentUser.status == 1 ? <Button
          fullWidth
          variant="contained"
          color="primary"
          className={classes.submit}
          onClick={() => { setEventOpen(true) }}
        >הוסף נושא/דיון
        </Button> : null}
        <Dialog open={eventOpen} onClose={() => { setEventOpen(false) }} >
          <DialogTitle id="form-dialog-title">הוספת דיון</DialogTitle>
          <DialogContent>
            <DialogContentText>
              וועד בית היקר. נא למלא פרטי הארוע
        </DialogContentText>
            <TextField
              autoFocus
              margin="dense"
              id="name"
              label="נושא הישיבה"
              type="text"
              fullWidth
              onChange={(e) => { setMeeting({ title: e.target.value, body: meeting.body, start_date: meeting.start_date, end_date: meeting.end_date }) }} />
            <TextField
              margin="dense"
              id="date"
              label="פרוט"
              type="text"
              fullWidth
              onChange={(e) => { setMeeting({ title: meeting.title, body: e.target.value, start_date: meeting.start_date, end_date: meeting.end_date }) }} />
            <TextField
              margin="dense"
              label="תאריך תחילת הישיבה"
              type="date"
              fullWidth
              InputProps={{ inputProps: { min: today } }}
              onChange={(e) => { setMeeting({ title: meeting.title, body: meeting.body, start_date: e.target.value, end_date: meeting.end_date }) }} />
            <TextField
              margin="dense"
              label="סגירת הישיבה"
              type="date"
              fullWidth
              InputProps={{ inputProps: { min: meeting.start_date } }}
              onChange={(e) => { setMeeting({ title: meeting.title, body: meeting.body, start_date: meeting.start_date, end_date: e.target.value }) }} />
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
        {message.type ? <Alert severity={message.type}>{message.text}</Alert> : null}
        {mee ? mee.map((option) => (
          <div key={option.id_meeting} >
            <div>
              <p style={{ textAlign: 'right' }}>
                {option.meeting_subject} <label>:נושא הישיבה</label> <br />
                {option.meeting_description} <label>:פרוט</label> </p>
              <IconButton onClick={(e) => handleVote("1", option)} style={{ color: '#00c853' }} aria-label="add an alarm">
                <SentimentSatisfiedAltIcon />
              </IconButton>
              <IconButton onClick={(e) => handleVote("2", option)} style={{ color: '#ff1744' }} aria-label="add an alarm">
                <SentimentVeryDissatisfiedIcon />
              </IconButton>
              {currentUser && currentUser.status == 1 ? <Button fullWidth variant="contained" color="primary" type="submit" className={classes.submit} onClick={(e) => { showVote(e, option) }}>
                הראה הצבעות
</Button> : null}
              {voteData ? <div style={{ width: '200px', height: '200px' }} >	<Doughnut data={voteData} />
                <IconButton onClick={() => { setVoteData(null) }} color="primary">
                  <CancelIcon />
                </IconButton>
              </div>
                : null}
            </div>
            {comments.length > 0 ?
              <div>
                <CommentsBlock
                  comments={comments.filter(t => t.id_meeting == option.id_meeting)}
                  isLoggedIn={true}
                  onSubmit={(e) => handleComment(e, option)}
                  style={{
                    btn: base => ({
                      ...base,
                      background: 'red',
                    }),
                  }}
                />
              </div>
              : null}
          </div>
        )) : null
        }
      </div>
    </Container>
  );
}