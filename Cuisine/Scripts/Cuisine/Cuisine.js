function ViewCategory()
{
    $.ajax({
        type:'post',
        url:"/Category/CategoryListMenu",
        success:function(html)
        {
            $("#sidebar").html(html);
        }
    });
}

function ViewProduct(categoryId) {
    window.location = "/Product/ListByCategory/" + categoryId;
    
}

function DeleteFromBasket(ProductId) {
    $.ajax({
        type: "post",
        url: "/Order/RemoveFromCart?ProductId=" + ProductId,
        success: function (html) {
            $("#divShoppingCard").html(html);
        }
    });
}
function UpdateBasket(ProductId) {
    $.ajax({
        type: "post",
        url: "/Order/AddToCart?ProductId=" + ProductId,
        success: function (html) {
            $("#divShoppingCard").html(html);
        }
    });
}


function AddDeal(ProductId) {
    $.ajax({
        type: "post",
        url: "/Order/AddToCart?ProductId=" + ProductId,
        success: function (html) {
            window.location.href = '/Order';
        }
    });
}

function OrderCuisine() {
    $.ajax({
        type: "post",
        url: "/Order/GetOrderDetails",
        success: function (html) {
        $.blockUI({
            message: html, 
                css: { top: '10%',left: '36%',width:'28%', right: '36%',bottom:'10%' }
            });
        }
    });
}

function OrderOnline() {
    if (ValidateInput()) {
        var order = getOrder();
        $.ajax({
            type: "post",
            url: $("#OrderAction").val(),
            data: order,
            dataType: 'json',
            success: function (data) {
                if (data.IsSuccess == true) {
                    $("#generalRequired").show();
                    $("#generalRequired").html('<h5 style="color:green"> Order has been successfully added. Thanks for your order!</h5>');
                }
                else {
                    $("#generalRequired").show();
                    $("#generalRequired").html('<h5 style="color:red"> Order has not been added. Sorry! </h5><h5 style="color:red"> ' + data.ErrorMessage + '</h5>');
                }
            }
        });
    }
}

function ValidateInput() {
    if ($("#FirstName").val() == "") 
    {
        $("#firstNameRequired").show();
                return false;
    }
    if ($("#LastName").val() == "") 
    {
        $("#lastNameRequired").show();
                return false;
    }
    if ($("#Address").val() == "") 
    {
        $("#addressRequired").show();
                return false;
    }
    if ($("#Phone").val() == "") 
    {
        $("#phoneRequired").show();
                return false;
    }
    if ($("#PostalCode").val() == "") 
    {
        $("#postCodeRequired").show();
                return false;
    }
    if ($("#Email").val() == "") 
    {
        $("#emailRequired").show();
                return false;
    }
    return true;
}

function getOrder() {
    var FirstName = $("#FirstName").val();
    var LastName = $("#LastName").val();
    var Address = $("#Address").val();
    var Phone = $("#Phone").val();
    var PostalCode = $("#PostalCode").val();
    var Email = $("#Email").val();

    // poor man's validation
    return { FirstName: FirstName, LastName: LastName, Address: Address, Phone: Phone, PostalCode: PostalCode, Email: Email };
}