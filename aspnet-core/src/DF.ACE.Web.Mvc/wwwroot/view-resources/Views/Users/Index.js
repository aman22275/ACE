(function () {
    $(function () {

        var _userService = abp.services.app.user;
        var _additionalUserProfileService = abp.services.app.additionalUserProfile;
        var _$modal = $('#UserCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
            rules: {
                Password: "required",
                ConfirmPassword: {
                    equalTo: "#Password"
                }
            }
        });

        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-user').click(function () {
            var userId = $(this).attr("data-user-id");
            var userName = $(this).attr('data-user-name');

            deleteUser(userId, userName);
        });

        $('.edit-user').click(function (e) {
            var userId = $(this).attr("data-user-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Users/EditUserModal?userId=' + userId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#UserEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var user = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            var additionalUserInfo = _$form.serializeFormToObject();

            //Create an object to combine data of both DTOs
            var combinedInfo = {
                CreateUserDto: {},
                CreateAdditionalUserProfileDto: {}
            };

            //Combine dataof both DTOs
            combinedInfo.CreateUserDto = user;
            combinedInfo.CreateAdditionalUserProfileDto = additionalUserInfo;
            console.log(combinedInfo);

            combinedInfo.CreateUserDto.roleNames = [];
            var _$roleCheckboxes = $("input[name='role']:checked");
            if (_$roleCheckboxes) {
                for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                    var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                    combinedInfo.CreateUserDto.roleNames.push(_$roleCheckbox.val());
                }
            }
                    
            abp.ui.setBusy(_$modal);
            _additionalUserProfileService.createProfileWithAddition(combinedInfo).done(function () {
                    _$modal.modal('hide');
                    location.reload(true); //reload page to see new user!    

            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshUserList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteUser(userId, userName) {
            swal({
                title: 'Warning',
                text: abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'ACE'), userName),
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#36c6d3',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Cancel'
            }).then(function (result) {
                if (result.value) {
                    _additionalUserProfileService.deleteProfileWithAddition({
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