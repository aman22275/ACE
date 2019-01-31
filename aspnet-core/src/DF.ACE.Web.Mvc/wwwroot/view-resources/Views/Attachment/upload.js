(function () {
    $(function () {

       // var _uploadService = abp.services.app.upload;
        var _$form = $('form[name=filesUploadForm]');

        _$form.validate({
            rules: {
                files: {
                    required: true,
                    accept: "jpg,png,jpeg,gif,doc,txt"
                }
            },
            messages: {
                files: {
                    required: 'Please select file(s)!',
                    accept: "Only jpg/png/jpeg/gif/doc/txt filetypes are allowed!"
                }
            }
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var formDta = new FormData();
            var filesData = new FormData();

            var userFiles = document.getElementById("files").files;    

            for (var i = 0; i < userFiles.length; i++) {
                formDta.append("files", userFiles[i]);
                filesData.append("userId", 1);
                formDta.append("filesDetailDto[" + i + "]", filesData);
            }     

            $.ajax({
                type: 'POST',
                url: '/Upload/CreateUpload',
                contentType: false,
                data: formDta,
                processData: false,
                success: function () {
                    location.reload(true);
                }
            });
        });
    });
})();