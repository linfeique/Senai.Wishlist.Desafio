import React, { Component } from 'react';
import axios from 'axios';

class List extends Comment{

    constructor(){
        super();

        this.state ={
            desejo: '',
            lista: []
        }
    }

    cadastrarDesejo(event){
        event.preventDefault();

        axios.post('http://localhost:5000/api/desejos' ,{
            desejo: this.state.desejo
        })
        .then(data => {
            listarDesejos();
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
        axios.get('http://localhost:5000/api/desejos')
        .then(data => this.setState({lista : data}))
        .catch(erro => console.log("Erro: ", erro))
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