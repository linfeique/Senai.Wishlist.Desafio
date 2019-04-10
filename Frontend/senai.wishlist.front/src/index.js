import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from '../src/Login/App';
import * as serviceWorker from './serviceWorker';
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import { usuarioAutorizado } from './services/auth';
import list from './Listagem/List';
import register from './CadastroUser/CadastroUser';

const Permissao = ({component : Component}) => (
    <Route 
        render = {props => usuarioAutorizado() ?
            (<Component {...props}/>) :
            (<Redirect to={{ pathname : '/login', state : {from: props.location} }}/>)
        }
    /> 
);

const rotas = (
    <Router>
        <div>
            <Switch>
                <Route exact path="/" component={App}/>
                <Permissao path="/lista" component={list}/>
                <Route path="/cadastro" component={register} />
            </Switch>
        </div>
    </Router>
);

ReactDOM.render(rotas, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();