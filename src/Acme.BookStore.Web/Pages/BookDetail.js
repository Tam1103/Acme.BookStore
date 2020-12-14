$(function () {
    var l = abp.localization.getResource('BookStore');
    var baseUrl = (window.location).href; // You can also use document.URL
    var id = baseUrl.substring(baseUrl.lastIndexOf('?') + 1);

    abp.ajax({
        type: 'GET',
        url: 'api/app/book/' + id
    }).then(function (result) {
        $("#name").html( result.name),
        $("#authorName").html(result.authorName),
        $('#price').html(result.price);
        $('#image').html('<img width="200" height="200" src="my-files/host/my-file-container/' + result.image + '"/>')
    });
});