import React, { Component } from 'react';
import './CadastroUser.css';
import Axios from 'axios';

export default class Cadastro extends Component {
    constructor() {
        super();
        this.state = {
            email: '',
            senha: ''
        }
    }

    atualizaEstadoEmail(event) {
        this.setState({ email: event.target.value });
    }

    atualizaEstadoSenha(event) {
        this.setState({ senha: event.target.value });
    }

    cadastrarUsuario(event) {
        event.preventDefault();

        Axios.post('http://192.168.56.1:5000/api/usuarios/', {
            email: this.state.email,
            senha: this.state.senha
        })
            .then(data => {
                this.props.history.push('/');
            })
            .catch(erro => console.log(erro))
    }

    render() {
        return (
            <div>
                <div id="background"></div>
                <div id="opac">
                    <form onSubmit={this.cadastrarUsuario.bind(this)} className="cadastro-inputboxshadow">
                        <h1>Cadastre-se</h1>
                        <div className="cadastro-inputs">
                            <div className="cadastro-email">
                                <input
                                    id="input"
                                    type="email"
                                    placeholder="E-mail"
                                    value={this.state.email}
                                    onChange={this.atualizaEstadoEmail.bind(this)}
                                />
                            </div>
                            <div className="cadastro-senha">
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
                            <button type="submit">Cadastrar</button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}