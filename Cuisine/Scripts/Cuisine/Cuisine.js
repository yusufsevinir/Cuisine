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

function OrderOnline(event) {
    event.preventDefault();
    $.ajax({
        type: "post",
        url: $("#OrderAction").val(),
        data: $(".form-stacked").serialize(),
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