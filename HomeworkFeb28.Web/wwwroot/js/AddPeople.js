$(() => {
    let rowcount = 1;
    $("#add-rows").on('click', function () {
        $("#ppl-rows").append(`<div class="row" style="margin-bottom: 10px;">
        <div class="col-md-4">
            <input class="form-control" type="text" name="people[${rowcount}].firstname" placeholder="First Name" />
        </div>
        <div class="col-md-4">
            <input class="form-control" type="text" name="people[${rowcount}].lastname" placeholder="Last Name" />
        </div>
        <div class="col-md-4">
            <input class="form-control" type="text" name="people[${rowcount}].age" placeholder="Age" />
        </div>
        </div>`);
        rowcount++;                          
    });
});