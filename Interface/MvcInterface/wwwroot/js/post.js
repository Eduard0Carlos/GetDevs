function postData() {
    console.log("foi")
    var educations = {
        "Educations": [{
            "InstitutionName": "teste1"
        }, {
            "InstitutionName": "teste2"
        }]
    }
    $.ajax({
        type: "POST",
        url: "/Resume/Index",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(educations)
    }).done(function (result) {
        console.log(JSON.stringify(educations))
        console.log("FOI")
        console.log(result);
    });
}