

function loadThuoc(url){
    try {
        $.ajax({
            url: "/api/thuoc/" + url,
            method: "GET",
            //data: "",
            contentType: "application/json",
            dataType: "json",
        }).done(function (data) {
            debugger;
            if (data) {
                    $('div.product-list.card-deck').empty();
                    $('div.products').append(`<div class="product-list card-deck">
                                            </div>`)
                    $.each(data, function (index, item) {
                        var customerInfoHTML = $(`<div class="product-item card text-center">
                                                <a href="/Home/product/`+ item['MaThuoc'] + `"><img src="/Content/Images/` + item['URLAnh'] + `"></a>
                                                <h4><a href="/Home/product/`+ item['MaThuoc'] + `">` + item['TenThuoc'] + `</a></h4>
                                                <p>Giá Bán: <span>`+ item['DonGia'] + ` VNĐ</span></p>
                                            </div>`);
                        $('div.product-list.card-deck').append(customerInfoHTML);
                    })
            }
        }).fail(function (response) {
            alert("Có lỗi xảy ra vui lòng liên hệ với chúng tôi để được trợ giúp");
        })
    }
    catch (e) {
        console.log(e);
    }
}

function loadDanhMuc(url) {
    try {
        $.ajax({
            url: "/api/danhmuc/" + url,
            method: "GET",
            //data: "",
            contentType: "application/json",
            dataType: "json",
        }).done(function (data) {
            if (data) {
                $('div.product-list.card-deck').empty();
                $.each(data, function (index, item) {
                    var customerInfoHTML = $(`<a class="dropdown - item menu-item" id="menu" href="/Home/DANHMUC/` + item['MaDM']+`">
                                                    `+item['TenDM']+`
                                                </a>`);
                    $('div.dropdown-menu#mydropdown').append(customerInfoHTML);
                })
            }
        }).fail(function (response) {
            alert("Có lỗi xảy ra vui lòng liên hệ với chúng tôi để được trợ giúp");
        })
    }
    catch (e) {
        console.log(e);
    }
}

function loadThuoc1(url) {
    try {
        $.ajax({
            url: "/api/thuoc/getthuoc/" + url,
            method: "GET",
            //data: "",
            contentType: "application/json",
            dataType: "json",
        }).done(function (data) {
            console.log(data);
            if (data) {
                $('div.breadcrumbs').append(`<a href="">` + data['TenThuoc'] + `</a>`);
                var InfoHTML = $(`<div id="product-img" class="col-lg-6 col-md-6 col-sm-12">
                                                <img src="/Content/Images/`+data['URLAnh']+`">
                                            </div>
                                            <div id="product-details" class="col-lg-6 col-md-6 col-sm-12">
                                                <h1>`+data['TenThuoc']+`</h1>
                                                <ul>
                                                    <li><span>Dạng thuốc: </span>`+ data['DangThuoc']+`</li>
                                                    <li><span>Đơn vị: </span>`+ data['DonVi']+`</li>
                                                    <li id="price">Giá Bán</li>
                                                    <li id="price-number">`+ data['DonGia']+` VNĐ</li >
                                                    <li id="status">Còn hàng</li>
                                                </ul>
                                                <!-- Thêm vào giỏ -->
                                                <div id="add-cart">
                                                </div>
                                            </div>`);                                                  
                $('div#product-top.row').append(InfoHTML);
                var CheckSLT;
                if (data['SoLuongTon'] > 0) {
                    CheckSLT = $(`<a href = "/Cart/AddItem/` + data['MaThuoc'] + `" > Mua ngay</a >`);
                }
                else {
                    CheckSLT = $(`<a href="">Hết Hàng</a>`);
                }
                $('div#add-cart').append(CheckSLT);

                var iInfoHTML = $(`<div class="product-buttom-content">
                    <h3>Giới thiệu sản phẩm</h3>
                    <p>
                        <h5>Công dụng: ` + data['CongDung']+`</h5>
                        <h5>Liều lượng sử dụng: `+ data['LieuLuong']+`</h5>
                        <h5>Thành phần thuốc: `+ data['ThanhPhan']+`</h5>
                    </p>
                </div>`);
                $('div#product-bottom.row').append(iInfoHTML);
            }
        }).fail(function (response) {
            alert("Có lỗi xảy ra vui lòng liên hệ với chúng tôi để được trợ giúp");
        })
    }
    catch (e) {
        console.log(e);
    }
}

function loadDiaChi(url) {
    try {
        $.ajax({
            url: "/api/diachi/getdiachiKH/" + url,
            method: "GET",
            contentType: "application/json",
            dataType: "json",
        }).done(function (data) {
            if (data) {
                alert
                $.each(data, function (index, item) {
                    var customerInfoHTML = $(`<option value="` + item['DiaChi1'] + `">` + item['DiaChi1'] +`</option>`);
                    $('select#DiaChi').append(customerInfoHTML);
                })
            }
        }).fail(function (response) {
            alert("Có lỗi xảy ra vui lòng liên hệ với chúng tôi để được trợ giúp");
        })
    }
    catch (e) {
        console.log(e);
    }
}
