var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7223/SignalRHub").build();
document.getElementById("sendbutton").disabled = true;
//->sendbutton Id'li input pasif olsun
connection.on("ReceiveMessage", function (user, message) {//user ve message SignalRHub->SendMessage Metodu
    var currentTime = new Date();//değişkenlere güncel saat ve dakikaları tanımlıyor
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");//bir liste değeri oluştur
    var span = document.createElement("span");//bir span değeri oluştur
    span.style.fontWeight = "bold";//spanın fontu kalın olsun
    span.textContent = user;//spanın içeriğine mesajlarımı alma işlemi
    li.appendChild(span);//listelere spanın içeriğini uygula ve görüntüle
    li.innerHTML += ` :${message} - ${currentHour}:${currentMinute}`;
    //liste formatında nelerin geleceğini ve gösterileceğini gösterir
    document.getElementById("messagelist").appendChild(li);
    //messagelist ID'li UL'mde li'deki değerleri uygula ve göster
});

connection.start().then(function () {//bağlantım açıldığında
    document.getElementById("sendbutton").disabled = false;//sendbutton'aktif olsun
}).catch(function (err) {//eğerki olurda bir hata olursa o hatayı konsolda göstersin
    return console.error(err.toString());
});
//butona tıklanınca ne olacak 
//addEventListener("click") ->//event adında bir fonksiyon oluştursun
document.getElementById("sendbutton").addEventListener("click", function (event) {
    //userinput ve messageinput'dan alınan veriler değişkenlere atansın
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;
    //SignalRHub'daki SendMessage metodumu yukarda aldığım değişkenlerimdeki değerlerle
    //çağırdım ve parametre olarak yolladım 
    //herhangi bir metodla ilgili hata olursa hatayı yakalayıp console tarafında yazdırdım
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
