#!/usr/bin/env node

var fib = require('./fib');
var amqp = require('amqplib/callback_api');
var fileStream = require('fs');

const output = "C:\\Users\\Vadim\\Source\\rep\\ADA\\Lab2\\moutput.txt";

var queue_channel;

var consumeMessage = async function(msg) {
	try {
		var n = msg.content.toString();
		console.log("Receiver {X} JS" + n);
		
		var result = await fib.sleepyFibonacci(n);
		
		fileStream.appendFile(output, result + "\n", function (err) {
			if (err) throw err;
			});
			
		queue_channel.ack(msg);
	}
	catch(ex) {
		console.log(ex);
	}
}


amqp.connect('amqp://localhost', function(connectError, connection) {
    if (connectError) {
        throw connectError;
    }

    connection.createChannel(function(channelError, channel) {
        if (channelError) {
            throw channelError;
        }
		
		queue_channel = channel;
		
		channel.prefetch(1);
        channel.assertQueue(queueName, { durable: false });

        console.log("[*] Message", queueName);

        channel.consume(queueName, consumeMessage, { noAck: false });
    });
});