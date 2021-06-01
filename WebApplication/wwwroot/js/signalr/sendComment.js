const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

let userName = '';
let count = 0;
hubConnection.on('Send', function (message, userName, rating) {
    if (count > 1)
        message = 'Вы уже оставили отзыв'
    document.getElementById("chatroom").innerHTML = message
    count++;
});

document.getElementById("sendBtn").addEventListener("click", function (e) {
    let message = document.getElementById("message").value;
    let rating = document.getElementById("rating").value;
    let book = document.getElementById("book").value;
    let username = document.getElementById("username").value;
    hubConnection.invoke("Send", message, rating, book, username, count < 1);
});

hubConnection.start();