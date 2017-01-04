/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Areas/Admin/Content/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Areas/Admin/Content/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Areas/Admin/Content/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Areas/Admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Areas/Admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/Areas/Admin/Content/ckfinder/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    //FCKConfig.ProcessHTMLEntities = false;
    CKFinder.setupCKEditor(null, '/Areas/Admin/Content/ckfinder/');

};
