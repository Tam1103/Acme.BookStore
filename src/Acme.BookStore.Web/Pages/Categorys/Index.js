$(function () {
    var l = abp.localization.getResource('BookStore');

    var dataTable = $('#CategoryTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.authors.author.getList),
            columnDefs: [
                {
                    title: l('Author title'),
                    data: { name: "name", id: "id" },
                    "render": function (data) {
                        return '<a href="categorys/booklist?' + data.id + '">'
                            + '    <div class="panel-text">'
                            + '        <span>' + data.name + '</span>'
                            + '    </div>'
                            + '</a>'
                    }
                }, 

                {
                    title: l('BirthDate'),
                    data: "birthDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('Detail'),
                    data: { name: "name", id: "id" },
                    "render": function (data) {
                        return '<a href="categorys/booklist?' + data.id + '">'
                            + '    <div class="panel-text">'
                            + '        <span>' + l('All book') + '</span>'
                            + '    </div>'
                            + '</a>'
                    }
                }, 
            ]
        })
    );
});
