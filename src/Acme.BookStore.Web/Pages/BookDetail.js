$(function () {
    var l = abp.localization.getResource('BookStore');
    var baseUrl = (window.location).href; // You can also use document.URL
    var id = baseUrl.substring(baseUrl.lastIndexOf('?') + 1);

    abp.ajax({
        type: 'GET',
        url: 'api/app/book/' + id
    }).then(function (result) {
        $("#BooksTable").html('<h6>' + '<h1>' + "Book Name = " + result.name + '</h6>' +
            '<h6>' + '<h1>' + "Author Name = " + result.authorName + '</h6>' +
            '<h6>' + '<h1>' + "Price = " + result.price + '</h6>'
        );
    });
});