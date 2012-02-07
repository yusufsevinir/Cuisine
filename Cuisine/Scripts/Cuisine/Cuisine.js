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
            $.blockUI({ message: html, css: { top: '10%'} }
                );
            //            $("#GetDetailsDiv").html(html);
            //                left: '40%', right: '40%',bottom:'10%' } 
        }
    });
}

function OrderOnline() {
    $.ajax({
        type: "post",
        url: "/Order/Order",
        contentType: 'application/json',
        data: JSON.stringify({ newOrder: $("#OrderForm").serializeArray() }),

//        data: $("#OrderForm").serialize(),
//        dataType: "json",
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