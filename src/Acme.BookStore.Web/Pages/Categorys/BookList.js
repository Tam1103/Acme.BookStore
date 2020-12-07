$(function () {
    
    var l = abp.localization.getResource('BookStore');
    var baseUrl = (window.location).href; // You can also use document.URL
    var id = baseUrl.substring(baseUrl.lastIndexOf('?') + 1);

    debugger;

    abp.ajax({
        type: 'GET',
        url: '/api/app/book/' + id + '/byCategoryId'
    }).then(function (result) {
        $.each(result, function (key, value) {
            $("#example2").append(
                + '<tbody>'
                + '    <tr>'

                + '    <td>'
                + '        <p> ' + value.name + '</p>'
                + '    </td>'

                
                + '    <td>'
                + '<img width="200" height="200" src="/my-files/host/my-file-container/' + value.image + '"/>'
                + '    </td>'

                + '    <td>'
                + '        <a href = "/BookDetail?' + value.id + '" > ' + "Detail" + '</a > '
                + '    </td>'

                + '    </tr>'
                + '</tbody>'
            );
        });
    });
});