(function(b,a){b.create("tinymce.plugins.EPiTrailing",{init:function(e,c){var d=this;e.onSetContent.add(function(f,g){d._insertTrailingElement(f);});e.onChange.add(function(h,f,g){d._insertTrailingElement(h);});e.onPreProcess.add(function(f,g){d._trimEmptyElements(f,g);});},getInfo:function(){return{longname:"Trailing element",author:"EPiServer AB",authorurl:"http://www.episerver.com",infourl:"http://www.episerver.com",version:1};},_insertTrailingElement:function(e){var c=e.getBody();var d=c&&c.lastChild;if(!c||!d){return;}if(e.dom.isBlock(d)&&d.tagName!=="P"){c.appendChild(e.dom.create("p",null,'<br _mce_bogus="1" />'));}},_trimEmptyElements:function(f,c){if(!c.get){return;}if(c.node.childNodes.length===1){return;}var e=c.node.lastChild;while(e&&e.nodeName==="P"&&e.childNodes.length==1&&e.firstChild.nodeName=="BR"){f.dom.remove(e);e=c.node.lastChild;}var d=c.node.firstChild;while(d&&d.nodeName==="P"&&d.childNodes.length==1&&d.firstChild.nodeName=="BR"){f.dom.remove(d);d=c.node.firstChild;}}});b.PluginManager.add("epitrailing",b.plugins.EPiTrailing);}(tinymce,epiJQuery));