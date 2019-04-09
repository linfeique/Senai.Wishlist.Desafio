import React from 'react';
import './CadastroUser.css';

export default class Cadastro extends Component {
    render() {
        return (
            <div>
                <div id="background"></div>
                <div id="opac">
                    <form onSubmit={this.efetuaLogin.bind(this)} className="inputboxshadow">
                        <div className="inputs">
                            <hr />
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
                            <button type="submit">Cadastrar</button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}