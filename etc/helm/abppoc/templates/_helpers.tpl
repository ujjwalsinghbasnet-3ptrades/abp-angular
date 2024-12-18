{{- define "abppoc.hosts.webpublic" -}}
{{- print "https://" (.Values.global.hosts.webpublic | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "abppoc.hosts.httpapi" -}}
{{- print "https://" (.Values.global.hosts.httpapi | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "abppoc.hosts.angular" -}}
{{- print "https://" (.Values.global.hosts.angular | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
