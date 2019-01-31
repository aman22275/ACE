//Attachment
(function () {
   
    $(function () {
        
        var _attachmentService = abp.services.app.attachment;

        $('.delete-user').click(function () {
            var userId = $(this).attr("data-user-id");
            var title = $(this).attr('data-user-name');            
            deleteUser(userId, title);
        });

        function refreshUserList() {
            location.reload(true); //reload page to see new user!
        }
       
        function deleteUser(userId, title) {
            swal({
                title: 'Warning',
                text: abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'ACE'), title),
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#36c6d3',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Cancel'
            }).then(function (result) {
                if (result.value) {
                    _attachmentService.delete({
                        id: userId
                    }).done(function () {
                        refreshUserList();
                    });
                } else if (result.dismiss == 'cancel') {
                    return false;
                }

            });
        }
    });
})();