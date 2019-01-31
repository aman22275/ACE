(function ($) {

   // var _userService = abp.services.app.user;
    var _additionalUserProfileService = abp.services.app.additionalUserProfile;
    var _$modal = $('#UserEditModal');
    var _$form = $('form[name=UserEditForm]');

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var user = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
        var additionalUserInfo = _$form.serializeFormToObject();


        //Create an object to combine data of both DTOs
        var combinedInfo = {
            UserDto: {},
            AdditionalUserProfileDto: {}
        };

        //Combine data of both DTOs
        combinedInfo.UserDto = user;
        combinedInfo.AdditionalUserProfileDto = additionalUserInfo;
        console.log(combinedInfo);

        combinedInfo.UserDto.roleNames = [];
        var _$roleCheckboxes = $("input[name='role']:checked");
        if (_$roleCheckboxes) {
            for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                combinedInfo.UserDto.roleNames.push(_$roleCheckbox.val());
            }
        }

        abp.ui.setBusy(_$form);
        _additionalUserProfileService.updateProfileWithAddition(combinedInfo).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited user!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.find(':submit').click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);