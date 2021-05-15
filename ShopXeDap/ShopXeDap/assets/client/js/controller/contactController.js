var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {

        $('#frmLienHe').validate({
            rules: {
                txtName: {
                    required: true,
                },
                txtMobile: {
                    required: true,
                    number: true
                },
                txtAddress: {
                    required: true,
                },
                txtEmail: {
                    required: true,
                    email: true
                },
                txtContent: {
                    required: true,
                }
            },
            messages: {
                txtName: {
                    required: "Bạn phải nhập tên",
                },
                txtMobile: {
                    required: "Bạn phải nhập số điện thoại",
                    number: "Số điện thoại phải là số",
                },
                txtAddress: {
                    required: "Bạn phải nhập địa chỉ",
                },
                txtEmail: {
                    required: "Bạn phải nhập email",
                    email: "Bạn phải nhập địa chỉ email hợp lệ"
                },
                txtContent: {
                    required: "Bạn phải nhập nội dung",
                }
            }
        });

        $('#btnSend').off('click').on('click', function () {

            if ($('#frmLienHe').valid()) {
                var name = $('#txtName').val();
                var mobile = $('#txtMobile').val();
                var address = $('#txtAddress').val();
                var email = $('#txtEmail').val();
                var content = $('#txtContent').val();

                $.ajax({
                    url: '/Contact/Send',
                    type: 'POST',
                    dataType: 'json',
                    data: {
                        name: name,
                        mobile: mobile,
                        address: address,
                        email: email,
                        content: content
                    },
                    success: function (res) {
                        if (res.status == true) {
                            window.alert('Gửi thành công');
                            contact.resetForm();
                        }
                    }
                });
            }
        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtMobile').val('');
        $('#txtAddress').val('');
        $('#txtEmail').val('');
        $('#txtContent').val('');
    }
}
contact.init();