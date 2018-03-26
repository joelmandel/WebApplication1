// Write your JavaScript code.
$('#addItem').click(function () {
    $.ajax({
        url: this.href,
        data: { rowCount: $('#myTable tr').length - 1 },
        success: function (html) {
            $('#myTable tr:last').after(html);
          

        }

    })
    return false;
})


$(document).on('focusout', '.price-input,qty-input', function () {
  //  $('.price-input,.qty-input').focusout(function () {
    var total = 0;
    $('#myTable tr').each(function () {
        $this = $(this);
        var price = parseFloat($this.find("input.price-input").val());
        var qty = parseFloat($this.find("input.qty-input").val());
        var loTotal = $this.find("p.total-cell");
        if (!Number.isNaN(price) && !Number.isNaN(qty)) {
            total += (qty * price);
            loTotal.text('$'+ (qty * price).toFixed(2));
        }

    });
    alert(total);
    $('#total').text(total.toFixed(2));

    return true;
});
