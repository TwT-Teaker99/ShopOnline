
var remove_cart = document.getElementsByClassName('btn-danger')
for (var i = 0; i < remove_cart.length; i++) {
    var button = remove_cart[i]
    button.addEventListener("click", function () {
        var button_remove = event.target
        button_remove.parentElement.parentElement.remove()
        updateCart()
    })
}

function updateCart() {
    var cartItems = document.getElementsByClassName('cart-items')[0]
    var cartRows = cartItems.getElementsByClassName('cart-item')
    var total = 0;
    for (var i = 0; i < cartRows.length; i++) {
        var cartRow = cartRows[i]
        var quantity_item = cartRow.getElementsByClassName('quantity')[0]
        var price_item = cartRow.getElementsByTagName("b")[0]
        var price = parseFloat(price_item.innerText.replace(',', ''))
        var quantity = quantity_item.value
        total = total + (price * quantity)

    }
    document.getElementsByClassName('cart-total-price')[0].innerText = Comma(total) + 'VNĐ'
}


var quantity_input = document.getElementsByClassName("quantity");
for (var i = 0; i < quantity_input.length; i++) {
    var input = quantity_input[i];
    input.addEventListener("change", function (event) {
        var input = event.target
        if (isNaN(input.value) || input.value <= 0) {
            input.value = 1;
        }
        updateCart()
    })
}

function Comma(number) {
    number = '' + number;
    if (number.length > 3) {
        var mod = number.length % 3;
        var output = (mod > 0 ? (number.substring(0, mod)) : '');
        for (i = 0; i < Math.floor(number.length / 3); i++) {
            if ((mod == 0) && (i == 0))
                output += number.substring(mod + 3 * i, mod + 3 * i + 3);
            else
                output += ',' + number.substring(mod + 3 * i, mod + 3 * i + 3);
        }
        return (output);
    }
    else return number;
}



