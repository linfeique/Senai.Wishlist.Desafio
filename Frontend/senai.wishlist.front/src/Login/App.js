import React, { Component } from 'react';
import './App.css';
import logo from './assets/images/wishlist.svg';
import Axios from 'axios';
import {Link} from 'react-router-dom';

export default class App extends Component {
  constructor(){
    super();
    this.state={
      email : '',
      senha : ''
    }
  }

  atualizaEstadoEmail(event){
    this.setState({email : event.target.value});
  }

  atualizaEstadoSenha(event){
    this.setState({senha : event.target.value});
  }

  efetuaLogin(event){
    event.preventDefault();

    Axios.post('http://localhost:5000/api/login', {
        email : this.state.email,
        senha : this.state.senha    
    })
    .then(data=>{
        localStorage.setItem("user-wishlist", data.data.token);
        this.props.history.push('/lista');
        console.log(data);
    })
    .catch(erro=>{
        console.log(erro);
    })
}

render() {
  return (
      <div>
          <div id="background"></div>
          <div id="opac">
              <form onSubmit={this.efetuaLogin.bind(this)} className="inputboxshadow">
                  <div className="circulo">
                      <img src={logo} alt="Logo" />
                  </div>
                  <div className="inputs">
                      <hr />
                      <span>Seja bem-vindo ao WishList</span>
                      <div className="email">
                          <input
                              id="input"
                              type="email"
                              placeholder="E-mail"
                              value={this.state.email}
                              onChange={this.atualizaEstadoEmail.bind(this)}
                          />
                      </div>
                      <div className="senha">
                          <input
                              id="input"
                              type="password"
                              placeholder="Senha"
                              value={this.state.senha}
                              onChange={this.atualizaEstadoSenha.bind(this)}
                          />
                      </div>
                  </div>
                  <div className="btn">
                      <hr />
                      <span>Não tem conta no sistema ainda? <Link to="/cadastro">Clique Aqui!</Link></span>
                      <button type="submit">Entrar</button>
                  </div>
              </form>
          </div>
      </div>
  );
}
}