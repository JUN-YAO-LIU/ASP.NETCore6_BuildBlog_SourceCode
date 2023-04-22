/**
 * @license Copyright (c) 2014-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
 */
import ClassicEditor from '@ckeditor/ckeditor5-editor-classic/src/classiceditor.js';
import Alignment from '@ckeditor/ckeditor5-alignment/src/alignment.js';
import AutoImage from '@ckeditor/ckeditor5-image/src/autoimage.js';
import Bold from '@ckeditor/ckeditor5-basic-styles/src/bold.js';
import CKFinderUploadAdapter from '@ckeditor/ckeditor5-adapter-ckfinder/src/uploadadapter.js';
import CodeBlock from '@ckeditor/ckeditor5-code-block/src/codeblock.js';
import Essentials from '@ckeditor/ckeditor5-essentials/src/essentials.js';
import FontBackgroundColor from '@ckeditor/ckeditor5-font/src/fontbackgroundcolor.js';
import FontColor from '@ckeditor/ckeditor5-font/src/fontcolor.js';
import FontSize from '@ckeditor/ckeditor5-font/src/fontsize.js';
import GeneralHtmlSupport from '@ckeditor/ckeditor5-html-support/src/generalhtmlsupport.js';
import Highlight from '@ckeditor/ckeditor5-highlight/src/highlight.js';
import Image from '@ckeditor/ckeditor5-image/src/image.js';
import ImageCaption from '@ckeditor/ckeditor5-image/src/imagecaption.js';
import ImageResize from '@ckeditor/ckeditor5-image/src/imageresize.js';
import ImageStyle from '@ckeditor/ckeditor5-image/src/imagestyle.js';
import ImageToolbar from '@ckeditor/ckeditor5-image/src/imagetoolbar.js';
import ImageUpload from '@ckeditor/ckeditor5-image/src/imageupload.js';
import PageBreak from '@ckeditor/ckeditor5-page-break/src/pagebreak.js';
import Paragraph from '@ckeditor/ckeditor5-paragraph/src/paragraph.js';
//import ImageResizeEditing from '@ckeditor/ckeditor5-image/src/imageresize/imageresizeedititing';
//import ImageResizeButtons from '@ckeditor/ckeditor5-image/src/imageresize/imageresizebuttons';

class Editor extends ClassicEditor { }

// Plugins to include in the build.
Editor.builtinPlugins = [
    Alignment,
    AutoImage,
    Bold,
    CKFinderUploadAdapter,
    CodeBlock,
    Essentials,
    FontBackgroundColor,
    FontColor,
    FontSize,
    GeneralHtmlSupport,
    Highlight,
    Image,
    ImageCaption,
    //ImageResize,
    //ImageStyle,
    //ImageToolbar,
    ImageUpload,
    PageBreak,
    Paragraph,
];

// Editor configuration.
Editor.defaultConfig = {
    toolbar: {
        items: [
            'bold',
            'fontColor',
            'fontSize',
            'fontBackgroundColor',
            'alignment',
            'highlight',
            'imageUpload',
            'pageBreak',
            'codeBlock',
            'undo',
            'redo'
        ]
    },
    language: 'en',
    image: {
        resizeOptions: [
            {
                name: 'resizeImage:original',
                label: 'Original',
                value: null
            },
            {
                name: 'resizeImage:100',
                label: '100px',
                value: '100'
            },
            {
                name: 'resizeImage:200',
                label: '200px',
                value: '200'
            }
        ],
        toolbar: [

        ]
    }
};

export default Editor;