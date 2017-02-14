/// <reference path="../ckfinder/ckfinder.html" />
/// <reference path="../ckfinder/ckfinder.html" />
/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For the complete reference:
    // http://docs.ckeditor.com/#!/api/CKEDITOR.config
	
	config.toolbar = [
                        ['Source', 'Preview', 'Templates'],
                        ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
                        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
                        '/',
                        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote', 'CreateDiv'],
                        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
                        ['BidiLtr', 'BidiRtl'],
                        ['Link', 'Unlink', 'Anchor'],
                        ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'],
                        '/',
                        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
                        ['Styles', 'Format', 'Font', 'FontSize'],
                        ['TextColor', 'BGColor'],
                        ['Maximize', 'ShowBlocks', 'Syntaxhighlight']
    ]

	// Remove some buttons, provided by the standard plugins, which we don't
	// need to have in the Standard(s) toolbar.
	config.removeButtons = 'Underline,Subscript,Superscript';

	// Se the most common block elements.
	config.format_tags = 'p;h1;h2;h3;pre';

	// Make dialogs simpler.
	config.removeDialogTabs = 'image:advanced;link:advanced';

	config.filebrowserBrowseUrl = '/Assets/Admin/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Assets/Admin/plugins/ckfinder/ckfinder.html?type=Images';
    config.filebrowserUploadUrl = '/Assets/Admin/plugins/ckfinder/connector?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Assets/Admin/plugins/ckfinder/connector?command=QuickUpload&type=Images';

};

