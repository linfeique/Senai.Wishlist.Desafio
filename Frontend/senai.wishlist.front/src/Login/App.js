import React, { Component } from 'react';
import './App.css';
import logo from './assets/images/wishlist.svg';

class App extends Component {
  render() {
    return (
      <div>
        <div id="background"></div>
          <div id="opac">
            <form className="inputboxshadow">
                <div className="circulo">
                  <img src={logo} alt="Logo"/>
                </div>
                <div className="inputs">
                  <hr/>
                  <span>Seja bem-vindo ao WishList</span>
                  <div className="email">
                    <input type="email" placeholder="E-mail" id="input"/>
                  </div>
                  <div className="senha">
                    <input type="password" placeholder="Senha" id="input" />
                  </div>
                </div>
                <div className="btn">
                  <hr/>
                  <input type="button" value="Entrar" />
                </div>
            </form>
          </div>
        </div>
    );
  }
}

export default App;
