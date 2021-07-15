// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


// Load Graph with Search data
function GetSynonyms() {
    $.ajax({
        type: "GET",
        url: "/Advanced/GetSynonyms",
        success: function (data) {
            PopulateList(data);           
        }
    });
}



//$(document).ready(function () {
  
//});
