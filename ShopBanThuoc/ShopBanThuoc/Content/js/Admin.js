function loadDanhMuc() {
    try {
        $.ajax({
            url: "/api/danhmuc/getlistdanhmuc",
            method: "GET",
            contentType: "application/json",
            dataType: "json",
        }).done(function (data) {
            debugger;
            if (data) {
                $.each(data, function (index, item) {
                    var customerInfoHTML = $(`<tr>
									<td style="">`+ item['MaDM'] +`</td>
									<td style="">`+ item['TenDM'] +`</td>
									<td class="form-group">
										<a href="/ADMIN/Admin/Edit_DanhMuc/`+ item['MaDM'] +`" class="btn btn-primary"><i class="glyphicon glyphicon-pencil"></i></a>
										<a href="/ADMIN/Admin/Del_DanhMuc/`+ item['MaDM'] +`" class="btn btn-danger"><i class="glyphicon glyphicon-remove"></i></a>
									</td>
								</tr>`);
                    $('table#DanhMucContent').append(customerInfoHTML);
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