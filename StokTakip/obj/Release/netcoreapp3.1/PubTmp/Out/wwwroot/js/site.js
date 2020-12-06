function StokUpdate(productId) {
    
    $.ajax({
        url: "/Product/GetById",
        method: "post",
        data: { productId: productId },
        dataType: "json",
        global: true,
        success: function (response) {
            if (response.success) {
                $("#UrunAdi").empty();
                $("#UrunAdi").append(response.productname);
                $("#PrdouctModal").modal('toggle');
                $("#OkButton").click(function () {
                    var stokGiris = $("#Adet").val();
                    $.ajax({
                        url: "/Product/StockUpdate",
                        method: "post",
                        data: { productId: productId, stokGiris: stokGiris },
                        dataType: "json",
                        global: true,
                        success: function (response) {
                            if (response.success) {
                                
                                $("#PrdouctModal").modal('toggle');
                                window.location.href = "/Product/Index";
                            }
                            else {
                                alert(response.message)

                            }
                        }
                    });
                });
            }
            else {
                alert(response.message)

            }
        }
    });
}

$(document).ready(function () {
    $("#Kullanici").click(function () {
        $("#ImgDiv").empty();
        $("#InfoDiv").empty();
        var imgText = "<img src='/image/IslemPaneli1.png'/>";
        $("#ImgDiv").append(imgText);
        var InfoText = "<br/><br/><b>•İşlem Paneli bölümünde bulunan Kullanıcı İşlemleri sekmesiyle sisteme giriş yapabilecek yeni bir kullanıcı<br/> eklenebilir veya mevcut kullanıcının, kullanıcı adı ve şifresi güncellenebilir.</b><br/><br/><br/><img style = 'width: -1%;height: 120px;' src = '/image/IslemPaneli2.png'/><br/><br/><br/><b>Uygulama açıldığında mustafa kullanıcı direk aktif olacaktır.<br /> Bu kullanıcı ve size verilen şifre ile giriş yapabilirsiniz.</b> ";
        $("#InfoDiv").append(InfoText);
    });
    $("#Sube").click(function () {
        $("#ImgDiv").empty();
        $("#InfoDiv").empty();
        var imgText = "<img src='/image/IslemPaneli3.png'/>";
        $("#ImgDiv").append(imgText);
        var InfoText = "<br/><br/><b>•İşlem Paneli bölümünde bulunan Şube İşlemleri sekmesiyle sisteme yeni bir şube <br/> eklenebilir veya mevcut şube güncellenebilir.</b><br/><br/><br/><img style = 'width: -1%;height: 120px;' src = '/image/IslemPaneli4.png'/><br/><br/><br/><b>Sol üste bulunan Yeni Şube butonu ile şube eklenebilir</b><br/><b>Düzenle butonu ile Şube bilgileri güncellenebilir</b>";
        $("#InfoDiv").append(InfoText);
    });
    $("#UrunStok").click(function () {
        console.log("UrunStok");
    });
    $("#Teslimat").click(function () {
        console.log("Teslimat");
    });
});