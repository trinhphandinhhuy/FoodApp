// To add a new product to the cookie
function addCookie(name, ingredientname, amount, unit) {

    var today = new Date();

    //to set the cookies expiry time
    var expires = expires * 1000 * 3600 * 3;

    //To retrieve the values of cookie named "ShoppingCart"
    var currentCookie = getCookie(name);

    if (currentCookie == null) {
        //it means this is the first item in the basket
        document.cookie = name + '=' + escape(ingredientname) + "," + escape(amount) + "," + escape(unit) +
                        ((expires) ? ';expires=' + new Date(today.getTime() + expires).toGMTString() : '');
    }
    else {
        //it means the basket already has another products
        document.cookie = name + '=' + currentCookie + "," + escape(ingredientname) + "," + escape(amount) + "," + escape(unit) +
                        ((expires) ? ';expires=' + new Date(today.getTime() + expires).toGMTString() : '');
    }

    
    //to force the post back to reload the basket items after adding product
    __doPostBack('Basket1_UpdatePanel1', '');
}

// To retrieve the basket cookie values
function getCookie(name) {
    var sPos = document.cookie.indexOf(name + "=");
    var len = sPos + name.length + 1;
    if ((!sPos) && (name != document.cookie.substring(0, name.length))) {
        return null;
    }
    if (sPos == -1) {
        return null;
    }

    var ePos = document.cookie.indexOf('=', len);
    if (ePos == -1) ePos = document.cookie.length;
    return unescape(document.cookie.substring(len, ePos));
}
//End Adding new product code


//To remove a product from the basket. I am calling a JavaScript function deleteCookie when the user press on remove link. 
//then I am forcing postback by calling the function  __doPostBack function. 

function deleteCookie(name, ingredientname, amount, unit) {

    //to set the cookie expiry time
    var expires = expires * 1000 * 3600 * 3;

    //because the system will check the space as %20
    if (document.cookie.indexOf("%20") != -1) {
        prod_name = amount.replace(" ", "%20");
    }

    //In case of the removed item in the mid of the cookie
    if (document.cookie.indexOf("," + ingredientname + "," + amount + "," + unit) != -1) {
        document.cookie = document.cookie.replace("," + ingredientname + "," + amount + "," + unit, "") +
               ((expires) ? ';expires=' + new Date(today.getTime() + expires).toGMTString() : '');
    }

        //In case of the removed item is the first item in cookie
    else if (document.cookie.indexOf(ingredientname + "," + amount + "," + unit + ",") != -1) {
        document.cookie = document.cookie.replace(ingredientname + "," + amount + "," + unit + ",", "") +
               ((expires) ? ';expires=' + new Date(today.getTime() + expires).toGMTString() : '');
    }

        //In case of the removed item is the only item in cookie 
    else if (document.cookie.indexOf(ingredientname + "," + amount + "," + unit) != -1) {
        document.cookie = document.cookie.replace(ingredientname + "," + amount + "," + unit, "") +
               ((expires) ? ';expires=' + new Date(today.getTime() + expires).toGMTString() : '');
    }

    //to force the post back to reload the basket items after removing product 
    __doPostBack('Basket1_UpdatePanel1', '');
}


// This Javascript function to force a postback after adding or removing a product.  
function __doPostBack(eventTarget, eventArgument) {
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.__EVENTTARGET.value = eventTarget;
        theForm.__EVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
}
