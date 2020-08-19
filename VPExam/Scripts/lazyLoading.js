var ajaxCallUrl = 'Item/ItemList',
    page = 0,
    inCallback = false,
    isReachedScrollEnd = false;


var scrollHandler = function () {
    if (isReachedScrollEnd == false &&
        ($(document).scrollTop() <= $(document).height() - $(window).height())) {
        loadProducts(ajaxCallUrl);
    }
}
function loadProducts(ajaxCallUrl) {
    if (page > -1 && !inCallback) {
        inCallback = true;
        page++;
        $("div#loading").show();
        $.ajax({
            type: 'GET',
            url: ajaxCallUrl,
            data: "pageNumber=" + page,
            success: function (data, textstatus) {
                if (data != '') {
                    $("table > tbody").append(data);
                }
                else {
                    page = -1;
                }

                inCallback = false;
                $("div#loading").hide();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    }
}  
function AddItem(id, name) {
    var serviceURL = '/Cart/AddItem';

    $.ajax({
        type: "GET",
        url: serviceURL,
        data: {
            ItemId: id,
            ItemName: name
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: GetTotalCart,
        error: errorFunc
    });
};
function GetCart() {
    var serviceURL = '/Cart/Index';

    $.ajax({
        type: "GET",
        url: serviceURL,       
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: GetTotalCart,
        error: errorFunc
    });
};


function RemoveItem(id) {
    var serviceURL = '/Cart/RemoveItem';
    var myPostJSONObject = {
        Id: id
    };
    $.ajax({
        type: "POST",
        url: serviceURL,
        data: JSON.stringify(myPostJSONObject),
        traditional: true,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            window.location.href = "Cart";
        },
        error: errorFunc
    });
};
function RemoveItem(id) {
    var serviceURL = '/Cart/RemoveItem';
    var myPostJSONObject = {
        Id: id
    };
    $.ajax({
        type: "POST",
        url: serviceURL,
        data: JSON.stringify(myPostJSONObject),
        traditional: true,
        dataType: "html",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#cartListTbody").html(data);
            GetTotalCart();
        },
        error: errorFunc
    });
};
function GetTotalCart() {
    var serviceURL = '/Cart/GetTotal';
    $.ajax({
        type: "GET",
        url: serviceURL,
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",        
        success: successFunc,
        error: errorFunc
    });

};

function successFunc(data, status) {
    var span = document.getElementById("lblCartCount");
    span.textContent = data;
};

function errorFunc() {
    alert('error');
};
function reloadCartList()
{
    var serviceURL = '/Cart/CartList';
    $.ajax({
        type: "GET",
        url: serviceURL,
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: GetTotalCart,
        error: GetTotalCart
    });
}