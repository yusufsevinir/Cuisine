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
       window.location="/Product/ListByCategory/"+categoryId;
}

function UpdateBasket(ProductId) {
    $.ajax({
        type: "post",
        url: "/Order/AddToCart?ProductId=" + ProductId,
        success: function (html) {
            $("#ProductOrderDiv").html(html);
        }
    });
}