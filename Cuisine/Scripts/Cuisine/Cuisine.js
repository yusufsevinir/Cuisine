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

function OrderCuisine() {
    $.ajax({
        type: "post",
        url: "/Order/GetOrderDetails",
        success: function (html) {
            $("#GetDetailsDiv").html(html);
        }
    });
}

function OrderOnline() {
    $.ajax({
        type: "post",
        url: "/Order/Order",
        data : $("#AddressForm").serialize(),
        success: function (text) {
            if (text == true) {
                $.blockUI({ message: '<h1> Order has been successfully added. Thanks for your order!</h1>' });
            }
            else {
                $.blockUI({ message: '<h1> Order has not been added. Sorry!</h1>' });
            }
            window.location = "/Home/Index";
        }
    });

}