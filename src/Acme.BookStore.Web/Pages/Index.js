$(function () {
    var l = abp.localization.getResource('BookStore');
    var editModal = new abp.ModalManager(abp.appPath + 'BookDetail');

      var result = abp.libs.datatables.createAjax(acme.bookStore.slides.slide.getList);
        $.each(result, function (key, value) {
            $("#slideMove").append(
                + '<img width="200" height="200" src="slide/' + value.name + '"/>'
            );
        });

    var dataTable = $('#AuthorsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.books.book.getList),
            columnDefs: [
                {
                    title: l('Book title'),
                    data: { name: "name", id: "id" },
                    "render": function (data) {
                        return  '<a href="bookdetail?' + data.id + '">'
                            + '    <div class="panel-text">'
                            + '        <span>' + data.name + '</span>'
                            + '    </div>'
                            + '</a>'
                    }
                }, 
                {
                    title: l('Author title'),
                    data: "authorName"
                },
                {
                    title: l('Action'),

                    data: {id: "id" },
                    "render": function (data) {
                        return '<a href="bookdetail?' + data.id + '">'
                            + '    <div class="panel-text">'
                            + '        <span>' + "Details" + '</span>'
                            + '    </div>'
                            + '</a>'
                    }
                }
            ]
        })
    );

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

});
