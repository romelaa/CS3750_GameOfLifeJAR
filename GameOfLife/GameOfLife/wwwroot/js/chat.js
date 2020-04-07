"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then(function () {
    console.log("Connected.");
    document.getElementById("sendButton").disabled = false;
    drawBox();
}).catch(function (err) {
    return console.error(err.toString());
});

let canvas = document.getElementById("canvas"), c = canvas.getContext("2d");

var cells = [];
var cellNum;


canvas.addEventListener('click', handleClick);

function drawBox() {
    c.beginPath();
    c.fillStyle = "white";
    c.lineWidth = 3;
    c.strokeStyle = 'black';
    for (var row = 0; row < 16; row++) {
        for (var column = 0; column < 16; column++) {
            var x = column * 50;
            var y = row * 50;
            c.rect(x, y, 50, 50);
            c.fill();
            c.stroke();
        }
    }
}

function handleClick(e) {
  /*  var selectedColor = document.getElementById("selectedColor").value;

    c.fillStyle = "#" + selectedColor;

    let x = e.offsetX;
    let y = e.offsetY;

    c.fillRect(Math.floor(x / 50) * 50,
        Math.floor(y / 50) * 50,
        48, 48);

    var row = Math.floor(x / 50);
    var col = Math.floor(y / 50);

    cellNum = row + (col * 16);*/
    var selectedColor = document.getElementById("selectedColor").value;
    //c.fillStyle = "#" + selectedColor;
    //create an array of cell objects that draws the gameboard the objects holds
    //the state(dead or alive) and color

    console.log(cells[cellNum]);
    var x = Math.floor(e.offsetX / 50);
    var y = Math.floor(e.offsetY / 50);
    cellNum = (x + (y * 16));


    if (cells[cellNum].color != "#FFFFFF") {
        c.fillStyle = "#FFFFFF"
        cells[cellNum].color = "#FFFFFF";

    }
    else {
        c.fillStyle = "#" + selectedColor;
        cells[cellNum].color = "#" + selectedColor;

    }


    c.fillRect((x * 50) + 1, (y * 50) + 1, 47, 47);

    console.log(cells);

    connection.invoke("NewCells", cellNum).catch(function (err) {
        return console.error(err.toString());
    });
}




connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);


});


document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});