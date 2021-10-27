import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Alert from '@material-ui/lab/Alert';
import MenuItem from '@material-ui/core/MenuItem';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import { Redirect } from "react-router-dom";
import Moment from 'moment';
import Tooltip from '@material-ui/core/Tooltip';
import IconButton from '@material-ui/core/IconButton';
import AddCircleOutlineIcon from '@material-ui/icons/AddCircleOutline';
import { useDispatch, useSelector } from "react-redux";
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


export default function Volunteering() {
    const classes = useStyles();
    const { user: currentUser } = useSelector((state) => state.auth);
    const [volunteerManager, setVolunteerManager] = useState({
        id_building: null, id_volunteering_category: null,
        volunteering_description: null, start_date: null, end_date: null, requred: false, status: null, nim_time: null, max_time: null
    })
    const [volunteerTelant, setVolunteerTelant] = useState({
        id_building: null, id_telant: null,
        id_volunteering: null, start_date: null, end_date: null, done: false
    })
    const [category, setCategory] = useState()
    const [volunteeringArray, setVolunteeringArray] = useState()
    const [eventOpen, setEventOpen] = useState(false)
    const [message, setMessage] = useState({ type: null, test: null })
    const [message1, setMessage1] = useState({ type: null, test: null })
    const [categoryId, setCategoryId] = useState(null)
    const [today, setToday] = useState(Moment(new Date()).format('yyyy-MM-DD'))
    const [addCategoryOpen, setAddCategoryOpen] = useState(false)
    const [redirect, setRedirect] = useState()
    const [actionCategoryForAdd, setActionCategoryForAdd] = useState({ description_volunteering_category: null, id_bulding: currentUser.id_building })
    const [getNewCategory, setGetNewCategory] = useState(false)
    const [volunteerDisable, setVolunteerDisable] = useState(false)

    useEffect(() => {
        const url = 'https://localhost:44350/api/VolunteeringCategory/GetVolunteeringCategorysOfBuilding/'
        const newUrl = url + currentUser.id_building
        axios(newUrl, {
            method: "get",
            headers: {
                "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
            }
        }).then(res => {
            setCategory(res.data)
            console.log(res.data, "category");
        })
    }, [getNewCategory])
    useEffect(() => {
        if (category) {
            const url = 'https://localhost:44350/api/Volunteering/GetVolunteeringsOfBuilding/'
            const newUrl = url + currentUser.id_building
            axios(newUrl, {
                method: "get",
                headers: {
                    "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
                }
            }).then(res => {
                setVolunteeringArray(res.data)
            })
        }
    }, [category, getNewCategory])
    console.log(volunteeringArray, "volunteeringArray")
    console.log(category, "category")

    useEffect(() => {
        // debugger
        if (volunteerTelant.end_date) {
            let d = 24 * 60 * 60 * 1000
            const v = volunteeringArray.find(t => t.id_volunteering == volunteerTelant.id_volunteering)
            if (v.min_time && v.max_time) {
                if (Math.round(Math.abs((new Date(volunteerTelant.start_date) - new Date(volunteerTelant.end_date)) / d)) >= v.min_time &&
                    Math.round(Math.abs((new Date(volunteerTelant.start_date) - new Date(volunteerTelant.end_date)) / d)) <= v.max_time
                    && volunteerTelant.start_date >= v.start_date.split('T')[0] && volunteerTelant.end_date <= v.end_date.split('T')[0]) {
                    setVolunteerDisable(true)
                    setMessage1({ type: '', text: "" })
                }
                else { setMessage1({ type: 'error', text: "יש לבחור תאריך בטווח התקין" }) }
            } else {
                if (volunteerTelant.start_date >= v.start_date && volunteerTelant.end_date <= v.end_date)
                    setVolunteerDisable(true)
            }
        }
    }, [volunteerTelant.end_date])
    useEffect(() => {
        if (volunteerManager.id_building) {
            // debugger
            console.log(volunteerManager)
            axios.post(`https://localhost:44350/api/Volunteering/PostVolunteering`, volunteerManager)
                .then(res => {
                    console.log(res.data);
                    setGetNewCategory(!getNewCategory)
                    setMessage({ type: 'success', text: 'ההתנדבות נוספה בהצלחה:)' })
                }).catch(err => {
                    setMessage({ type: 'error', text: 'אראה שגיאה, ההתנדבות לא נוספה:(' })
                })
            setEventOpen(false)
        }
    }, [volunteerManager])
    useEffect(() => {
        if (volunteerTelant.done) {
            axios.post(`https://localhost:44350/api/Volunteer/PostVolunteer`, volunteerTelant)
                .then(res => {
                    console.log(res.data);
                    setMessage1({ type: 'success', text: 'כל הכבוד:)' })
                }).catch(err => {
                    setMessage1({ type: 'error', text: 'אראה שגיאה, ההתנדבות לא עודכנה:(' })
                })
        }
    }, [volunteerTelant])
    console.log(currentUser, "current")
    useEffect(() => {
        if (message.type) {
            setTimeout(() => {
                setMessage({ type: null, text: null })
            }, 2000)
        }
    }, [message])
    const handleChange = (e) => {
        setCategoryId(e.target.value)
    }
    console.log(categoryId, "categoryId")

    const saveVolunteer = () => {
        setVolunteerManager({ id_building: currentUser.id_building, id_volunteering_category: volunteerManager.id_volunteering_category, volunteering_description: volunteerManager.volunteering_description, start_date: volunteerManager.start_date, end_date: volunteerManager.end_date, requred: volunteerManager.requred, status: currentUser.status == 1 ? 1 : 2, min_time: volunteerManager.min_time, max_time: volunteerManager.max_time })
    }
    const onSubmit = () => {
        setVolunteerTelant({
            id_building: volunteerTelant.id_building, id_telant: volunteerTelant.id_telant,
            id_volunteering: volunteerTelant.id_volunteering, start_date: volunteerTelant.start_date, end_date: volunteerTelant.end_date, done: true
        })
    }
    const onSend = () => {
        setRedirect('/setVolunteer')
    }
    const saveNewCategory = () => {
        console.log(actionCategoryForAdd, "action fir add")
        axios.post(`https://localhost:44350/api/VolunteeringCategory/PostVolunteeringCategory`, actionCategoryForAdd)
            .then(res => {
                setAddCategoryOpen(false)
                setGetNewCategory(!getNewCategory)
            })
    }
    console.log(volunteerTelant, "volunteertelant")

    if (redirect) {
        return <Redirect to={redirect} />;
    }
    return (
        <Container component="main" maxWidth="xs">
            <CssBaseline />
            <div className={classes.paper}>
                <Typography component="h1" variant="h5">
                    התנדבויות
                </Typography>
                <Button
                    fullWidth
                    variant="contained"
                    color="secondary"
                    className={classes.submit}
                    onClick={() => { setEventOpen(true) }}
                >הוספת התנדבות
        </Button>
                {currentUser && currentUser.status == 1 ? <Button
                    fullWidth
                    variant="contained"
                    color="secondary"
                    className={classes.submit}
                    onClick={onSend}
                >
                    אישור התנדבויות חדשות
        </Button> : null}
                {message.type ? <Alert severity={message.type}>{message.text}</Alert> : null}
                <Dialog open={eventOpen} onClose={() => { setEventOpen(false) }} >
                    <DialogTitle id="form-dialog-title">הוספת התנדבות</DialogTitle>
                    <DialogContent>
                        <DialogContentText>
                            נא למלא פרטי ההתנדבות
        </DialogContentText>
                        <TextField
                            select
                            label="select"
                            value={category ? category.description_volunteering_category : category}
                            onChange={(e) => setVolunteerManager({ id_building: null, id_volunteering_category: e.target.value, volunteering_description: volunteerManager.volunteering_description, start_date: volunteerManager.start_date, end_date: volunteerManager.end_date, requred: volunteerManager.requred, status: currentUser.status == 1 ? 1 : 2, min_time: volunteerManager.min_time, max_time: volunteerManager.max_time })}
                            helperText="בחר קטגוריה"
                        >
                            {category ? category.map((option) => (
                                <MenuItem key={option.id_volunteering_category} value={option.id_volunteering_category}>
                                    {option.description_volunteering_category}
                                </MenuItem>
                            )) : null}
                        </TextField>
                        <Tooltip title="add category" aria-label="add">
                            <IconButton onClick={() => { setAddCategoryOpen(true) }} color="primary">
                                <AddCircleOutlineIcon />
                            </IconButton>
                        </Tooltip>
                        <TextField
                            margin="dense"
                            label="תאור/פרוט"
                            fullWidth
                            onChange={(e) => { setVolunteerManager({ id_building: null, id_volunteering_category: volunteerManager.id_volunteering_category, volunteering_description: e.target.value, start_date: volunteerManager.start_date, end_date: volunteerManager.end_date, requred: volunteerManager.requred, status: currentUser.status, min_time: volunteerManager.min_time, max_time: volunteerManager.max_time }) }}
                        />
                        <TextField
                            margin="dense"
                            id="date"
                            label="מתאריך"
                            type="date"
                            fullWidth
                            InputProps={{ inputProps: { min: today } }}
                            onChange={(e) => { setVolunteerManager({ id_building: null, id_volunteering_category: volunteerManager.id_volunteering_category, volunteering_description: volunteerManager.volunteering_description, start_date: e.target.value, end_date: volunteerManager.end_date, requred: volunteerManager.requred, status: currentUser.status, min_time: volunteerManager.min_time, max_time: volunteerManager.max_time }) }}
                        />
                        <TextField
                            margin="dense"
                            id="date"
                            label="עד תאריך"
                            type="date"
                            fullWidth
                            InputProps={{ inputProps: { min: volunteerManager.start_date } }}
                            onChange={(e) => { setVolunteerManager({ id_building: null, id_volunteering_category: volunteerManager.id_volunteering_category, volunteering_description: volunteerManager.volunteering_description, start_date: volunteerManager.start_date, end_date: e.target.value, requred: volunteerManager.requred, status: currentUser.status, min_time: volunteerManager.min_time, max_time: volunteerManager.max_time }) }}
                        />
                        <TextField
                            margin="dense"
                            id="min_time"
                            label="מספר ימים מינימלי"
                            type="number"
                            fullWidth
                            onChange={(e) => { setVolunteerManager({ id_building: null, id_volunteering_category: volunteerManager.id_volunteering_category, volunteering_description: volunteerManager.volunteering_description, start_date: volunteerManager.start_date, end_date: volunteerManager.end_date, requred: volunteerManager.requred, status: currentUser.status, min_time: e.target.value, max_time: volunteerManager.max_time }) }}
                        />
                        <TextField
                            margin="dense"
                            id="max_time"
                            label="מספר ימים מקסימלי"
                            type="number"
                            fullWidth
                            InputProps={{ inputProps: { min: volunteerManager.min_time } }}
                            onChange={(e) => { setVolunteerManager({ id_building: null, id_volunteering_category: volunteerManager.id_volunteering_category, volunteering_description: volunteerManager.volunteering_description, start_date: volunteerManager.start_date, end_date: volunteerManager.end_date, requred: volunteerManager.requred, status: currentUser.status, min_time: volunteerManager.min_time, max_time: e.target.value }) }}
                        />
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={volunteerManager.requred}
                                    onChange={(e) => { setVolunteerManager({ id_building: null, id_volunteering_category: volunteerManager.id_volunteering_category, volunteering_description: volunteerManager.volunteering_description, start_date: volunteerManager.start_date, end_date: volunteerManager.end_date, requred: e.target.checked, status: currentUser.status, min_time: volunteerManager.min_time, max_time: volunteerManager.max_time }) }}
                                    color="primary"
                                />
                            }
                            label="האם ההתנדבות חובה"
                        />
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={() => { setEventOpen(false) }} color="primary">
                            ביטול
        </Button>
                        <Button onClick={saveVolunteer} color="primary">
                            שמור
        </Button>
                    </DialogActions>
                </Dialog>
                <form className={classes.form} >
                    <TextField
                        className={classes.submit}
                        select
                        label=""
                        value={category}
                        onChange={handleChange}
                        helperText="נא בחר קטגוריה"
                    >
                        {category ? category.map((option) => (
                            <MenuItem key={option.id_volunteering_category} value={option.id_volunteering_category}>
                                {option.description_volunteering_category}
                            </MenuItem>
                        )) : null}
                    </TextField><br />
                    <TextField
                        className={classes.submit}
                        select
                        label=""
                        value={volunteeringArray}
                        onChange={(e) => {
                            setVolunteerTelant({
                                id_building: volunteerTelant.id_building, id_telant: volunteerTelant.id_telant,
                                id_volunteering: e.target.value, start_date: volunteerTelant.start_date, end_date: volunteerTelant.end_date, done: false
                            })
                        }}
                        helperText="נא בחר התנדבות"
                    >
                        {volunteeringArray ? volunteeringArray.filter(t => t.id_volunteering_category === categoryId && t.status == 1).map((option) => (
                            <MenuItem key={option.id_volunteering} value={option.id_volunteering}>
                                {option.volunteering_description}
                            </MenuItem>
                        )) : null}
                    </TextField>
                    {volunteerTelant.id_volunteering ? volunteeringArray.filter(t => t.id_volunteering === volunteerTelant.id_volunteering)
                        .map((option) => (
                            <div key={option.id_volunteering}>
                                <Typography align="right" variant="caption" display="block">
                                    &nbsp; תאריך התחלה להתנדבות  &nbsp;{option.start_date.split('T')[0]}
                                &nbsp; תאריך סיום להתנדבות   &nbsp;{option.end_date.split('T')[0]}
                                </Typography>
                                {option.max_time && option.min_time ? <Typography align="right" variant="caption" display="block">
                                    &nbsp; מינימום ימים  &nbsp;{option.min_time}
                                &nbsp; מקסימום ימים &nbsp; {option.max_time}
                                </Typography> : null}
                            </div>
                        )) : null}
                    <TextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        label="מתאריך"
                        name="start_date"
                        type="date"
                        InputProps={{ inputProps: { min: today } }}
                        onChange={(e) => {
                            setVolunteerTelant({
                                id_building: volunteerTelant.id_building, id_telant: volunteerTelant.id_telant,
                                id_volunteering: volunteerTelant.id_volunteering, start_date: e.target.value, end_date: volunteerTelant.end_date, done: false
                            })
                        }}
                    />
                    <TextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        name="end_date"
                        label="עד תאריך"
                        type="date"
                        InputProps={{ inputProps: { min: volunteerTelant.start_date } }}
                        onChange={(e) => {
                            setVolunteerTelant({
                                id_building: volunteerTelant.id_building, id_telant: volunteerTelant.id_telant,
                                id_volunteering: volunteerTelant.id_volunteering, start_date: volunteerTelant.start_date, end_date: e.target.value, done: false
                            })
                        }}
                    />
                    <Button
                        fullWidth
                        variant="contained"
                        color="primary"
                        className={classes.submit}
                        onClick={onSubmit}
                        disabled={!volunteerDisable}
                    >
                        התנדב
            </Button>
                    <Dialog open={addCategoryOpen} onClose={() => { setAddCategoryOpen(false) }} >
                        <DialogTitle id="add-dialog-title">הוספת קטגוריה</DialogTitle>
                        <DialogContent>
                            <TextField
                                autoFocus
                                margin="dense"
                                id="name"
                                label="שם הקטגוריה"
                                type="text"
                                fullWidth
                                onChange={(e) => { setActionCategoryForAdd({ description_volunteering_category: e.target.value, id_bulding: currentUser.id_building }) }}
                            />
                        </DialogContent>
                        <DialogActions>
                            <Button onClick={() => { setAddCategoryOpen(false) }} color="primary"> ביטול</Button>
                            <Button onClick={saveNewCategory} color="primary">שמור</Button>
                        </DialogActions>
                    </Dialog>
                    {message1.type ? <Alert severity={message1.type}>{message1.text}</Alert> : null}
                </form>
            </div>
        </Container>
    );
}