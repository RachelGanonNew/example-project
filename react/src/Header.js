import React,{useState,useEffect} from 'react';
import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import AccountCircle from '@material-ui/icons/AccountCircle';
import Switch from '@material-ui/core/Switch';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import FormGroup from '@material-ui/core/FormGroup';
import MenuItem from '@material-ui/core/MenuItem';
import Menu from '@material-ui/core/Menu';
import Tabs from './Tabs';
import { Redirect } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { logout } from "./actions/auth";


const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
}));
export default (props) => {
  console.log(props.user, "user")
  const classes = useStyles();
  const [user, setUser] = useState()
  const [auth, setAuth] = useState(true);
  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);
  const[redirect,setRedirect]=useState()
  const { user: currentUser } = useSelector((state) => state.auth);
  const dispatch = useDispatch();

  const logOut = () => {
    setRedirect('/login')
    dispatch(logout());
  };
  useEffect(() => {
    setUser(JSON.parse(localStorage.getItem('user')))
}, [])

  const handleMenu = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };
  console.log(currentUser,"current")
  if (redirect) {
    return <Redirect to={redirect}/>;
  }
  return (
    <div className={classes.root}>
      <AppBar position="static" style={{backgroundColor:'black'}}>
        <Toolbar>
          <Typography variant="h6" className={classes.title}>
            Building project
          </Typography>
          {currentUser && (
            <div>
              <IconButton
                aria-label="account of current user"
                aria-controls="menu-appbar"
                aria-haspopup="true"
                onClick={handleMenu}
                color="inherit"
              >
                <AccountCircle />
              </IconButton>
              <Menu
                id="menu-appbar"
                anchorEl={anchorEl}
                anchorOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                open={open}
                onClose={handleClose}
              >
                <MenuItem onClick={logOut}>logout</MenuItem>
              </Menu>
            </div>
          )}
        </Toolbar>
      </AppBar>
     {currentUser?<Tabs></Tabs>:null}
    </div>
  );
};
