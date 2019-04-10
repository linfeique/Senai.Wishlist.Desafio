import React, { Component } from 'react';
import axios from 'axios';

export default class List extends Component{

    constructor(){
        super();

        this.state ={
            desejo: '',
            lista: [],
            token: ''
        }
    }

    cadastrarDesejo(event){
        event.preventDefault();

        axios.post('http://localhost:5000/api/desejos' ,{
            desejo: this.state.desejo
        })
        .then(data => {
            this.listarDesejos();
            console.log(data);
        })
        .catch(erro => {
            console.log("Erro: ", erro);
        })
    }

    atualizaEstado(event){
        this.setState({ desejo : event.target.value });
    }

    listarDesejos(){

        const teste = localStorage.getItem('user-wishlist');

        fetch('http://192.168.56.1:5000/api/desejos', {
            method: 'GET',
            headers: {
                "Authorization": "Bearer "+ teste 
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
                    <input type="text" placeholder="Escreva seu desejo" value={this.state.desejo} onChange={this.atualizaEstado}/>  
                </form>
                <div className="lista">
                    <ul>
                        {
                            this.state.lista.map(function(desejo){
                                return (
                                    <li>
                                        {desejo.desejo}
                                    </li>
                                );
                            })
                        }
                    </ul>
                </div>
            </div>
        );
    }
}