import React from 'react';
import Websocket from 'react-websocket';

export class ProductDetail extends React.Component {
    displayName = ProductDetail.name

    constructor(props) {
        super(props);
        this.state = {
            count: 90
        };
    }

    refWebSocket = new WebSocket('ws://localhost:8888/Toolbox')

    handleData(data) {
        alert(data);
        let result = JSON.parse(data);
        this.setState({ count: this.state.count + result.movement });
    }

    sendMessage(message) {
        this.refWebSocket.sendMessage(message);
    }

    render() {
        return (
            <div>
                Count: <strong>{this.state.count} </strong>
                <button onClick={() => this.sendMessage("Version")} >Send Message</button>
                <Websocket url='ws://localhost:8888/Toolbox'
                    onMessage={this.handleData.bind(this)}
                    ref={Websocket => {
                        this.refWebSocket = Websocket;
                    }}/>
            </div>
        );
    }
}



//import React from 'react';
//import Websocket from 'react-websocket';

//export class ProductDetail extends React.Component {
//    displayName = ProductDetail.name

//    refWebSocket = new WebSocket('ws://localhost:8888/Toolbox')


//    constructor(props) {
//        super(props);
//        this.state = {
//            count: 90
//        };
//    }

//    handleData(data) {
//        let result = JSON.parse(data);
//        this.setState({ count: this.state.count + result.movement });
//    }

//    sendMessage(message) {
//        this.refWebSocket.sendMessage(message);
//    }

//    render() {
//        return (
//            <div>
//                Count: <strong>{this.state.count} </strong>


//                <button onClick={() => this.sendMessage("Version")} >Send Message</button>
//                <Websocket
//                    url=''
//                    onMessage={this.handleData.bind(this)}
//                    onOpen={this.handleOpen} onClose={this.handleClose}
//                    reconnect={true} debug={true}

//                    ref={Websocket => {
//                        this.refWebSocket = Websocket;
//                    }}

//                />
//            </div>
//        );
//    }
//}
