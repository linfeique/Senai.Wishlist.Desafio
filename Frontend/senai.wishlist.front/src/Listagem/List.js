import React, { Component } from 'react';
import axios from 'axios';
import jwt_decode from 'jwt-decode';

export default class List extends Component{

    constructor(){
        super();

        this.state ={
            desejo: '',
            lista: []
        }
    }

    cadastrarDesejo(event){
        event.preventDefault();

        fetch('http://localhost:5000/api/desejos', {
            method: "POST",
            body: JSON.stringify({desejo : this.state.desejo}),
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("user-wishlist")
            }
        })
        .then(resposta => resposta)
        .then(this.listarDesejos())
        .catch(erro => console.log("Erro: ", erro))
    }

    atualizaEstado(event){
        this.setState({ desejo : event.target.value });
    }

    listarDesejos(){
        fetch('http://localhost:5000/api/desejos', {
            method: 'GET',
            headers: {
                "Authorization": "Bearer " + localStorage.getItem('user-wishlist') 
            }
        })
        .then(resposta => resposta.json())
        .then(data => this.setState({lista : data}))
        .catch(erro => console.log(erro))
    }

    componentDidMount(){
        this.listarDesejos();
    }

    render() {
        return (
            <div>
                <div className="topo">
                    
                </div>
                <form className="inputs" onSubmit={this.cadastrarDesejo.bind(this)}>
                    <input type="text" placeholder="Escreva seu desejo" value={this.state.desejo} onChange={this.atualizaEstado.bind(this)}/>
                    <button type="submit">Enviar</button>
                </form>
                <div className="lista">
                    <ul>
                        {
                            this.state.lista.map(function(desejo){
                                const teste = jwt_decode(localStorage.getItem("user-wishlist"));

                                return (
                                    <div key={desejo.id}>
                                        <header>{teste.email}</header>
                                        <main>{desejo.desejo}</main>
                                        <footer>{desejo.dataCriacao}</footer>
                                    </div>
                                );
                            })
                        }
                    </ul>
                </div>
            </div>
        );
    }
}