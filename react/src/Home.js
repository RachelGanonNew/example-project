import React, { useState, useEffect } from 'react';
import { Redirect } from "react-router-dom";
import { Link } from 'react-router-dom';
import axios from 'axios';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import { Image } from 'semantic-ui-react'
import { Input } from '@material-ui/core'
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import ListItemText from '@material-ui/core/ListItemText';
import Checkbox from '@material-ui/core/Checkbox';
import IconButton from '@material-ui/core/IconButton';
import CommentIcon from '@material-ui/icons/Comment';
import MailIcon from '@material-ui/icons/Mail';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import { useDispatch, useSelector } from "react-redux";
import CachedIcon from '@material-ui/icons/Cached';
import Tooltip from '@material-ui/core/Tooltip';

const useStyles = makeStyles((theme) => ({
    root1: {
        width: '100%',
        maxWidth: 432,
        backgroundColor: 'transparent',
    },
    title: {
        textAlign: 'center',
        margin: '30px'
    },
    headd: {
        backgroundColor: 'transparent'
    },
    details: {
        textAlign: 'end',
        marginRight: '20px'
    }
}));

export default function Home() {
    const classes = useStyles();
    const [redirect, setRedirect] = useState()
    const { user: currentUser } = useSelector((state) => state.auth);
    const [tenants, setTenants] = useState(JSON.parse(localStorage.getItem('tenants')))
    const [updateTenant, setUpdateTenant] = useState(false)
    const [emailOpen, setEmailOpen] = useState(false)
    const [tenantToEmail, setTenantToEmail] = useState()
    const [message, setMessage] = useState({ title: '', body: '' })
    const [managerDialog, setManagerDialog] = useState(false)
    const [manager, setManager] = useState()

    useEffect(() => {
        const url = 'https://localhost:44350/api/Tenant/GetTenantsOfBuilding/'

        const newUrl = currentUser && currentUser.id_building ? url + currentUser.id_building : null


        axios(newUrl, {
            method: "get",
            headers: {
                "Content-Type": "application/json", "Access-Control-Allow-Origin": "*"
            }
        }).then(res => {
            localStorage.setItem('tenants', JSON.stringify(res.data))
            setTenants(res.data)
            console.log(res.data)
        })
    }, [updateTenant])


    const update_status = (e, d) => {
        debugger
        const title = "ברוכים הבאים לmy_building."
        const body = "ועד הבית אישר אתכם והנכם יכולים כעת להכנס לאתר ולהתנסות בשלל האפשרויות שאנחנו מציעים. בהצלחה"
        const newEmail = {
            toEmail: d.email, fromEmail: "mybuildingnoreplay@gmail.com", subjectOfEmail: title, bodyOfEmail: body
        }
        const t = {
            id_building: d.id_building, id_tenant: d.id_tenant, first_name: d.first_name, last_name: d.last_name,
            email: d.email, phone: d.phone, apartment_num: d.apartment_num, floor_num: d.floor_num, tz: d.tz, status: 2
        }
        axios.put(`https://localhost:44350/api/Tenant/PutTenant`, t)
            .then(res => {
                window.location.reload();
                console.log(res.data);
                axios.post(`https://localhost:44350/api/tenant/PostEmailToTenant`, newEmail)
                setUpdateTenant(!updateTenant)
            }).catch(err => {
            })
    }
    const handleToggle = (v) => () => {
        setTenantToEmail(v)
        setEmailOpen(true)
    }
    const handleSentToAll = () => {
        setTenantToEmail({ email: currentUser.email })
        setEmailOpen(true)
        //map sendMessage
    }
    const handleManager = () => {
        console.log(manager)
        const d = tenants.filter(t => t.id_tenant == manager)
        const t = {
            id_building: d[0].id_building, id_tenant: d[0].id_tenant, first_name: d[0].first_name, last_name: d[0].last_name,
            email: d[0].email, phone: d[0].phone, apartment_num: d[0].apartment_num, floor_num: d[0].floor_num, tz: d[0].tz, status: 1
        }
        axios.put(`https://localhost:44350/api/Tenant/PutTenant`, t)
            .then(res => {
                console.log(res.data);
                const t1 = {
                    id_building: currentUser.id_building, id_tenant: currentUser.id_tenant, first_name: currentUser.first_name, last_name: currentUser.last_name,
                    email: currentUser.email, phone: currentUser.phone, apartment_num: currentUser.apartment_num, floor_num: currentUser.floor_num, tz: currentUser.tz, status: 2
                }
                axios.put(`https://localhost:44350/api/Tenant/PutTenant`, t1)
                setManagerDialog(false)
            }).catch(err => {
            })
    }
    const sendMessage = () => {
        currentUser && currentUser.status == 1 ? setMessage({ title: "קבלת הודעה מועד הבית", body: message.body })
            : setMessage({ title: "קבלת הודעה מ" + currentUser.first_name + ' ' + currentUser.last_name, body: message.body })
        const tenantEmail = { toEmail: tenantToEmail.email, fromEmail: "mybuildingnoreplay@gmail.com", subjectOfEmail: message.title, bodyOfEmail: message.body }
        axios.post(`https://localhost:44350/api/Tenant/PostEmailToTenant`, tenantEmail)
            .then(res => {
                console.log(res.data);
                setEmailOpen(false)
            }).catch(err => {
                setEmailOpen(false)
            })
    }
    console.log(currentUser, "current")

    if (redirect) {
        return <Redirect to={redirect} />;
    }
    return (
        <div>
            <div className={classes.header}></div>
            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <div>
                    {currentUser && currentUser.first_name ?
                        <Typography component="h1" variant="h5" className={classes.title}>
                            {currentUser.first_name} {currentUser.last_name} ברוך הבא
                </Typography> : null}
                    {currentUser && currentUser.status == 1 ? <div>
                        {tenants && tenants.length > 1 && tenants.filter(t => t.status == 3).length > 0 ?
                            tenants.filter(t => t.status == 3).map(d => (<>
                                <Input defaultValue={d.first_name + ' ' + d.last_name} color="secondary" disabled />
                                <Button onClick={(e) => { update_status(e.target.value, d) }} color="primary">
                                    אשר דייר        </Button>
                            </>
                            ))
                            :
                            <Typography variant="caption" display="block">
                                אין דיירים לאישור
                    </Typography>
                        }
                        <Tooltip title="החלף וועד בית" aria-label="add">
                            <IconButton onClick={() => setManagerDialog(true)} color="primary">
                                <CachedIcon />
                            </IconButton>
                        </Tooltip>
                        <Dialog disableBackdropClick disableEscapeKeyDown open={managerDialog} onClose={() => setManagerDialog(false)}>
                            <DialogTitle>בחר וועד בית מהרשימה</DialogTitle>
                            <DialogContent>
                                <TextField
                                    select
                                    label="select"
                                    value={tenants ? tenants.id_tenant : tenants}
                                    onChange={(e) => { setManager(e.target.value) }}
                                    mame={tenants ? tenants.first_name + ' ' + tenants.last_name : tenants}
                                    helperText="בחר וועד בית חדש"
                                >
                                    {tenants ? tenants.map((option) => (
                                        option.status != 3 ?
                                            <MenuItem key={option.id_tenant} value={option.id_tenant}>
                                                {option.first_name + ' ' + option.last_name}
                                            </MenuItem> : null
                                    )) : null}
                                </TextField>
                            </DialogContent>
                            <DialogActions>
                                <Button onClick={() => setManagerDialog(false)} color="primary">
                                    ביטול
          </Button>
                                <Button onClick={handleManager} color="primary">
                                    אשר
          </Button>
                            </DialogActions>
                        </Dialog>
                    </div> : null}
                    <List className={classes.root1}>
                        {tenants ? tenants.map((value) => {
                            if (value.status != 3)
                                return (
                                    <ListItem className={classes.headd} key={value.id_tenant} role={undefined} dense button >
                                        <ListItemText className={classes.details} primary={
                                            `
                                            שם ${value.first_name + ' ' + value.last_name}
                                            נייד ${value.phone}
                                            מייל  ${value.email}     
                                           `} />
                                        <ListItemSecondaryAction>
                                            <IconButton edge="start" aria-label="comments" onClick={handleToggle(value)}>
                                                <MailIcon />
                                            </IconButton>
                                        </ListItemSecondaryAction>
                                    </ListItem>
                                );
                        }) : null
                        }
                    </List>
                    <Dialog open={emailOpen} onClose={() => { setEmailOpen(false) }} >
                        <DialogContent>
                            <TextField
                                margin="dense"
                                label="גוף ההודעה"
                                type="text"
                                fullWidth
                                onChange={(e) => { setMessage({ title: message.title, body: e.target.value }) }} />
                        </DialogContent>
                        <DialogActions>
                            <Button onClick={() => { setEmailOpen(false) }} color="primary">
                                ביטול
        </Button>
                            <Button onClick={sendMessage} color="primary">
                                שלח הודעה
        </Button>
                        </DialogActions>
                    </Dialog>
                    {currentUser && currentUser.status == 1 ?
                        <Button
                            color="primary"
                            onClick={handleSentToAll}
                        >
                            שלח הודעה לכל הדיירים
</Button> : null
                    }
                </div>
            </Container>
            <div className={classes.footer}></div>
        </div>
    );
}